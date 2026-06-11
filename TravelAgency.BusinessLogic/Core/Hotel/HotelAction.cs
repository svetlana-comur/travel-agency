using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Hotel;
using TravelAgency.Domains.Models.Hotel;
using TravelAgency.Domains.Models.Base;
using System.Linq;

namespace TravelAgency.BusinessLogic.Core.Hotel
{
    public class HotelAction
    {
        protected List<HotelDto> ExecuteGetAll()
        {
            using var db = new HotelContext();

            var hotels = db.Hotels
                .Include(x => x.Images)
                .Include(x => x.Rooms)
                .ToList();

            return hotels.Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address,
                City = h.City,
                Country = h.Country,

                ShortDescription = h.ShortDescription,
                FullDescription = h.FullDescription,

                Rating = h.Rating,
                Phone = h.Phone,
                BasePrice = h.BasePrice,

                Images = h.Images?
                    .Select(i => i.Url)
                    .ToList() ?? new List<string>()
            }).ToList();
        }

        protected HotelDto ExecuteGetById(int id)
        {
            using var db = new HotelContext();

            var hotel = db.Hotels
                .Include(x => x.Images)
                .Include(x => x.Rooms)
                .FirstOrDefault(x => x.Id == id);

            if (hotel == null)
                return null;

            return new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                Country = hotel.Country,

                ShortDescription = hotel.ShortDescription,
                FullDescription = hotel.FullDescription,

                Rating = hotel.Rating,
                Phone = hotel.Phone,
                BasePrice = hotel.BasePrice,

                Images = hotel.Images?
                    .Select(i => i.Url)
                    .ToList() ?? new List<string>()
            };
        }

        protected ResponceMsg ExecuteCreate(HotelDto dto)
        {
            using var db = new HotelContext();

            var exists = db.Hotels.Any(x => x.Name == dto.Name);

            if (exists)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Hotel already exists"
                };
            }

            var entity = new HotelData
            {
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,

                ShortDescription = dto.ShortDescription,
                FullDescription = dto.FullDescription,

                Rating = dto.Rating,
                Phone = dto.Phone,
                BasePrice = dto.BasePrice,

                Images = dto.Images?.Select(url => new HotelImgData
                {
                    Url = url
                }).ToList()
            };

            db.Hotels.Add(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Hotel created successfully"
            };
        }

        protected ResponceMsg ExecuteUpdate(HotelDto dto)
        {
            using var db = new HotelContext();

            var hotel = db.Hotels
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == dto.Id);

            if (hotel == null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Hotel not found"
                };
            }

            hotel.Name = dto.Name;
            hotel.Address = dto.Address;
            hotel.City = dto.City;
            hotel.Country = dto.Country;

            hotel.ShortDescription = dto.ShortDescription;
            hotel.FullDescription = dto.FullDescription;

            hotel.Rating = dto.Rating;
            hotel.Phone = dto.Phone;
            hotel.BasePrice = dto.BasePrice;

            hotel.Images?.Clear();

            if (dto.Images != null)
            {
                foreach (var img in dto.Images)
                {
                    hotel.Images.Add(new HotelImgData
                    {
                        Url = img
                    });
                }
            }

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Hotel updated successfully"
            };
        }

        protected ResponceMsg ExecuteDelete(int id)
        {
            using var db = new HotelContext();

            var hotel = db.Hotels.FirstOrDefault(x => x.Id == id);

            if (hotel == null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Hotel not found"
                };
            }

            db.Hotels.Remove(hotel);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Hotel deleted successfully"
            };
        }
    }
}