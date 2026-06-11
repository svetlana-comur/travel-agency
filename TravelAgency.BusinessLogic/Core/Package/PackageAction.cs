using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Package;
using TravelAgency.Domains.Models.Package;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Core.Package
{
    public class PackageAction
    {
        protected List<PackageDto> ExecuteGetAll()
        {
            using var db = new PackageContext();

            return db.Packages
                .Include(x => x.Images)
                .Select(x => new PackageDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    FullDescription = x.FullDescription,
                    DurationDays = x.DurationDays,
                    Price = x.Price,
                    Images = x.Images.Select(i => i.Url).ToList()
                })
                .ToList();
        }

        protected PackageDto ExecuteGetById(int id)
        {
            using var db = new PackageContext();

            var entity = db.Packages
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null) return null;

            return new PackageDto
            {
                Id = entity.Id,
                Name = entity.Name,
                ShortDescription= entity.ShortDescription,
                FullDescription = entity.FullDescription,
                DurationDays = entity.DurationDays,
                Price = entity.Price,
                Images = entity.Images.Select(i => i.Url).ToList()
            };
        }

        protected ResponceMsg ExecuteCreate(PackageDto dto)
        {
            using var db = new PackageContext();

            var entity = new PackageData
            {
                Name = dto.Name,
                ShortDescription = dto.ShortDescription, 
                FullDescription = dto.FullDescription,
                DurationDays = dto.DurationDays,
                Price = dto.Price,
                Images = dto.Images?.Select(x => new PackageImgData
                {
                    Url = x
                }).ToList()
            };

            db.Packages.Add(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Package created"
            };
        }

        protected ResponceMsg ExecuteUpdate(PackageDto dto)
        {
            using var db = new PackageContext();

            var entity = db.Packages
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == dto.Id);

            if (entity == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            entity.Name = dto.Name;
            entity.ShortDescription = dto.ShortDescription;
            entity.FullDescription = dto.FullDescription;
            entity.DurationDays = dto.DurationDays;
            entity.Price = dto.Price;

            db.PackageImgs.RemoveRange(entity.Images);

            entity.Images = dto.Images?.Select(x => new PackageImgData
            {
                Url = x,
                PackageId = entity.Id
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
            using var db = new PackageContext();

            var entity = db.Packages.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            db.Packages.Remove(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Deleted"
            };
        }
    }
}