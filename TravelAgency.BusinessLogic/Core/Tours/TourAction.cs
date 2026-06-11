using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Tour;
using TravelAgency.Domains.Enums;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Tour;

namespace TravelAgency.BusinessLogic.Core.Tours
{
    public class TourAction
    {
        protected List<TourDto> ExecuteGetAllToursAction()
        {
            using var db = new TourContext();

            var tData = db.Tours
                .Include(x => x.Images)
                .Include(x => x.Category)
                .ToList();

            return tData.Select(tour => new TourDto
            {
                Id = tour.Id,
                Name = tour.Name,

                ShortDescription = tour.ShortDescription,
                FullDescription = tour.FullDescription,

                CategoryId = tour.CategoryId,
                CategoryName = tour.Category?.Name,

                Images = tour.Images?
                    .Select(i => i.Url)
                    .ToList() ?? new List<string>(),

                Price = tour.Price,
                Status = tour.Status.ToString()
            }).ToList();
        }

        protected TourDto GetTourDataByIdAction(int id)
        {
            using var db = new TourContext();

            var tour = db.Tours
                .Include(x => x.Images)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);

            if (tour == null) return null;

            return new TourDto
            {
                Id = tour.Id,
                Name = tour.Name,

                ShortDescription = tour.ShortDescription,
                FullDescription = tour.FullDescription,

                CategoryId = tour.CategoryId,
                CategoryName = tour.Category?.Name,

                Images = tour.Images?
                    .Select(i => i.Url)
                    .ToList() ?? new List<string>(),

                Price = tour.Price,
                Status = tour.Status.ToString()
            };
        }

        protected ResponceMsg ExecuteTourCreateAction(TourDto tour)
        {
            using var db = new TourContext();

            var exists = db.Tours.Any(x => x.Name == tour.Name);

            if (exists)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Tour with this name already exists."
                };
            }

            var entity = new TourData
            {
                Name = tour.Name,
                Price = tour.Price,
                CategoryId = tour.CategoryId,
                Status = TourStatus.Active,

                ShortDescription = tour.ShortDescription,
                FullDescription = tour.FullDescription,

                Images = tour.Images?.Select(url => new TourImgData
                {
                    Url = url
                }).ToList()
            };

            db.Tours.Add(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Tour created successfully."
            };
        }

        protected ResponceMsg ExecuteTourUpdateAction(TourDto tour)
        {
            using var db = new TourContext();

            var entity = db.Tours
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == tour.Id);

            if (entity == null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Tour not found."
                };
            }

            entity.Name = tour.Name;
            entity.Price = tour.Price;
            entity.CategoryId = tour.CategoryId;

            entity.ShortDescription = tour.ShortDescription;
            entity.FullDescription = tour.FullDescription;

            entity.Images?.Clear();

            if (tour.Images != null)
            {
                foreach (var img in tour.Images)
                {
                    entity.Images.Add(new TourImgData
                    {
                        Url = img
                    });
                }
            }

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Tour updated successfully."
            };
        }

        protected ResponceMsg ExecuteTourDeleteAction(int id)
        {
            using var db = new TourContext();

            var entity = db.Tours.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Tour not found."
                };
            }

            db.Tours.Remove(entity);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Tour deleted successfully."
            };
        }
    }
}