using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Spa;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Spa;

namespace TravelAgency.BusinessLogic.Core.Spa
{
    public class SpaServiceAction
    {
        protected List<SpaServiceDto> ExecuteGetAll()
        {
            using var db = new SpaContext();

            return db.SpaServices
                .Include(x => x.Images)
                .Select(x => new SpaServiceDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    SpaSalonId = x.SpaSalonId,
                    Images = x.Images.Select(i => i.Url).ToList()
                })
                .ToList();
        }

        protected SpaServiceDto ExecuteGetById(int id)
        {
            using var db = new SpaContext();

            var service = db.SpaServices
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == id);

            if (service == null) return null;

            return new SpaServiceDto
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                SpaSalonId = service.SpaSalonId,
                Images = service.Images.Select(i => i.Url).ToList()
            };
        }

        protected ResponceMsg ExecuteCreate(SpaServiceDto dto)
        {
            using var db = new SpaContext();

            var entity = new SpaServiceData
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                SpaSalonId = dto.SpaSalonId,
                Images = dto.Images.Select(url => new SpaServiceImgData
                {
                    Url = url
                }).ToList()
            };

            db.SpaServices.Add(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Spa service created"
            };
        }

        protected ResponceMsg ExecuteUpdate(SpaServiceDto dto)
        {
            using var db = new SpaContext();

            var entity = db.SpaServices
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == dto.Id);

            if (entity == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Price = dto.Price;
            entity.SpaSalonId = dto.SpaSalonId;

            entity.Images.Clear();

            foreach (var img in dto.Images)
            {
                entity.Images.Add(new SpaServiceImgData
                {
                    Url = img
                });
            }

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Updated"
            };
        }

        protected ResponceMsg ExecuteDelete(int id)
        {
            using var db = new SpaContext();

            var entity = db.SpaServices.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            db.SpaServices.Remove(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Deleted"
            };
        }
    }
}