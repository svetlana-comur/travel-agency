using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Spa;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Spa;
using TravelAgency.Domains.Models.Booking;

namespace TravelAgency.BusinessLogic.Core.Spa
{
    public class SpaAction
    {
        protected List<SpaSalonDto> ExecuteGetAll()
        {
            using var db = new SpaContext();

            return db.SpaSalons
                .Include(x => x.Services)
                .Select(x => new SpaSalonDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone,
                    ShortDescription = x.ShortDescription,
                    FullDescription = x.FullDescription,
                    Services = x.Services.Select(s => new SpaServiceDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Description = s.Description,
                        Price = s.Price,
                        SpaSalonId = s.SpaSalonId
                    }).ToList()
                })
                .ToList();
        }

        protected SpaSalonDto ExecuteGetById(int id)
        {
            using var db = new SpaContext();

            var spa = db.SpaSalons
                .Include(x => x.Services)
                .FirstOrDefault(x => x.Id == id);

            if (spa == null) return null;

            return new SpaSalonDto
            {
                Id = spa.Id,
                Name = spa.Name,
                Address = spa.Address,
                Phone = spa.Phone,
                ShortDescription = spa.ShortDescription,
                FullDescription = spa.FullDescription,
                Services = spa.Services.Select(s => new SpaServiceDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,
                    SpaSalonId = s.SpaSalonId
                }).ToList()
            };
        }

        protected ResponceMsg ExecuteCreate(SpaSalonDto dto)
        {
            using var db = new SpaContext();

            var entity = new SpaSalonData
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone,
                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription
            };

            db.SpaSalons.Add(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Spa created"
            };
        }

        protected ResponceMsg ExecuteUpdate(SpaSalonDto dto)
        {
            using var db = new SpaContext();

            var spa = db.SpaSalons
                .FirstOrDefault(x => x.Id == dto.Id);

            if (spa == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            spa.Name = dto.Name;
            spa.Address = dto.Address;
            spa.Phone = dto.Phone;
            spa.ShortDescription = dto.ShortDescription;
            spa.FullDescription = dto.FullDescription;

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

            var spa = db.SpaSalons.FirstOrDefault(x => x.Id == id);

            if (spa == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            db.SpaSalons.Remove(spa);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Deleted"
            };
        }
    }
}