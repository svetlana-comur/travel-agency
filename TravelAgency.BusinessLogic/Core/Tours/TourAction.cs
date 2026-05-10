using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Tour;
using TravelAgency.Domains.Enums;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BusinessLogic.Core.Tours
{
    public class TourAction
    {
        protected List<TourDto> ExecuteGetAllToursAction()
        {
            var tours = new List<TourDto>();
            List<TourData> tData;

            using (var db = new TourContext())
            {
                //TODO: Add InerJoin to select on D3 and D4!
                tData = db.Tours.ToList();
            }

            foreach (var tour in tData)
            {
                var produc = new TourDto()
                {
                    Id = tour.Id,
                    Name = tour.Name,
                    Description = tour.Description,
                    CategoryId = tour.CategoryId,
                    Images = tour.Images,
                    Price = tour.Price
                };

                tours.Add(produc);
            }

            return tours;
        }
        protected TourDto GetTourDataByIdAction(int id)
        {

            TourData tData;
            using (var db = new TourContext())
            {
                //TODO: Add InerJoin to select on D3 and D4!
                tData = db.Tours.FirstOrDefault(x => x.Id == id);
            }

            return new TourDto()
            {
                Id = tData.Id,
                Name = tData.Name,
                Description = tData.Description,
                CategoryId = tData.CategoryId,
                Images = tData.Images,
                Price = tData.Price
            };
        }
        protected ResponceMsg ExecuteTourUpdateAction(TourDto tour)
        {
            using (var db = new TourContext())
            {
                var tData = db.Tours.FirstOrDefault(x => x.Id == tour.Id);
                if (tData == null)
                {
                    return new ResponceMsg { IsSuccess = false, Message = "Tour not found." };
                }

                tData.Name = tour.Name;
                tData.Description = tour.Description;
                tData.CategoryId = tour.CategoryId;
                tData.Images = tour.Images;
                tData.Price = tour.Price;

                db.SaveChanges();
            }

            return new ResponceMsg { IsSuccess = true, Message = "Tour updated successfully." };
        }
        protected ResponceMsg ExecuteTourDeleteAction(int id)
        {
            using (var db = new TourContext())
            {
                var tData = db.Tours.FirstOrDefault(x => x.Id == id);
                if (tData == null)
                {
                    return new ResponceMsg { IsSuccess = false, Message = "Tour not found." };
                }
                db.Tours.Remove(tData);
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "Tour deleted successfully." };
        }
        protected ResponceMsg ExecuteTourCreateAction(TourDto tour)
        {
            TourData tData;
            using (var db = new TourContext())
            {
                tData = db.Tours.FirstOrDefault(
                    x => x.Name.Equals(tour.Name));
            }

            if (tData != null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "An tour with this Name already exist in our system."
                };
            }

            var pLocalData = new TourData
            {
                Name = tour.Name,
                Price = tour.Price,
                Description = tour.Description,
                CategoryId = tour.CategoryId,
                Images = tour.Images,
                Status = TourStatus.Active
            };

            using (var db = new TourContext())
            {
                db.Tours.Add(pLocalData);
                db.SaveChanges();
            }

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Tour was succesfully added."
            };
        }
    }
}
