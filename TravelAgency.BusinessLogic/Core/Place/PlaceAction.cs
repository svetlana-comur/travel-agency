using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Place;
using TravelAgency.Domains.Models.Place;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Core.Place
{
    public class PlaceAction
    {
        protected List<PlaceDto> ExecuteGetAll()
        {
            using var db = new PlaceContext();

            return db.Places
                .Include(x => x.Country)
                .Select(x => new PlaceDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    FullDescription = x.FullDescription,
                    Price = x.Price,
                    CountryId = x.CountryId,
                    CountryName = x.Country.Name,
                    Images = x.Images.Select(i => i.Url).ToList()
                })
                .ToList();
        }

        protected PlaceDto ExecuteGetById(int id)
        {
            using var db = new PlaceContext();

            var entity = db.Places
                .Include(x => x.Country)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null) return null;

            return new PlaceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                ShortDescription = entity.ShortDescription,
                FullDescription = entity.FullDescription,
                Price = entity.Price,
                CountryId = entity.CountryId,
                CountryName = entity.Country?.Name,
                Images = entity.Images.Select(i => i.Url).ToList()
            };
        }

        protected ResponceMsg ExecuteCreate(PlaceDto dto)
        {
            using var db = new PlaceContext();

            db.Places.Add(new PlaceData
            {
                Name = dto.Name,
                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription,
                Price = dto.Price,
                CountryId = dto.CountryId,
                Images = dto.Images?.Select(url => new PlaceImgData
                {
                    Url = url
                }).ToList()
            });

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Place created"
            };
        }

        protected ResponceMsg ExecuteUpdate(PlaceDto dto)
        {
            using var db = new PlaceContext();

            var entity = db.Places
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == dto.Id);

            if (entity == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            entity.Name = dto.Name;
            entity.ShortDescription = dto.ShortDescription;
            entity.FullDescription = dto.FullDescription;
            entity.Price = dto.Price;
            entity.CountryId = dto.CountryId;

            db.PlaceImgs.RemoveRange(entity.Images);

            entity.Images = dto.Images?.Select(url => new PlaceImgData
            {
                Url = url,
                PlaceId = entity.Id
            }).ToList();

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Updated"
            };
        }

        protected ResponceMsg ExecuteDelete(int id)
        {
            using var db = new PlaceContext();

            var entity = db.Places.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            db.Places.Remove(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Deleted"
            };
        }
    }
}