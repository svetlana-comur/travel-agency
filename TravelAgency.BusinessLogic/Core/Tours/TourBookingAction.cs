using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Tour;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Booking;

namespace TravelAgency.BusinessLogic.Core.Tours
{
    public class TourBookingAction
    {
        protected ResponceMsg ExecuteCreateBookingAction(TourBookingDto dto)
        {

            using var db = new TourContext();

            var tour = db.Tours.FirstOrDefault(x => x.Id == dto.TourId);

            if (tour == null)
            {
                return new ResponceMsg { IsSuccess = false, Message = "Tour not found" };
            }

            var booking = new TourBookingData
            {
                TourId = dto.TourId,
                UserId = dto.UserId,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                Status = "Pending",

                FullName = dto.FullName,
                DepartureCity = dto.DepartureCity,
                Guests = dto.Guests,
                PaymentMethod = dto.PaymentMethod,

                TotalPrice =
                    tour.Price *
                    Math.Max(1, (dto.DateTo - dto.DateFrom).Days) *
                    Math.Max(1, dto.Guests)
            };

            db.TourBookings.Add(booking);
            
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Created" };
        }

        protected List<TourBookingDto> ExecuteGetUserBookingsAction(int userId)
        {
            using var db = new TourContext();

            return db.TourBookings
                .Where(x => x.UserId == userId)
                .Select(x => new TourBookingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    TourId = x.TourId,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    Status = x.Status
                })
                .ToList();
        }

        protected List<TourBookingDto> ExecuteGetAllBookingsAction()
        {
            using var db = new TourContext();

            return db.TourBookings
                .Select(x => new TourBookingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    TourId = x.TourId,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    Status = x.Status
                })
                .ToList();
        }

        protected ResponceMsg ExecuteCancelBookingAction(int id)
        {
            using var db = new TourContext();

            var b = db.TourBookings.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            b.Status = "Cancelled";
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Cancelled" };
        }

        protected ResponceMsg ExecuteConfirmBookingAction(int id)
        {
            using var db = new TourContext();

            var b = db.TourBookings.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            b.Status = "Confirmed";
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Confirmed" };
        }

        protected ResponceMsg ExecuteUpdateBookingAction(TourBookingDto dto)
        {
            using var db = new TourContext();

            var booking = db.TourBookings
                .FirstOrDefault(x => x.Id == dto.Id);

            if (booking == null)
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Booking not found"
                };

            var tour = db.Tours
                .FirstOrDefault(x => x.Id == dto.TourId);

            if (tour == null)
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Tour not found"
                };

            booking.UserId = dto.UserId;
            booking.TourId = dto.TourId;
            booking.DateFrom = dto.DateFrom;
            booking.DateTo = dto.DateTo;

            booking.TotalPrice =
                tour.Price * Math.Max(1, (dto.DateTo - dto.DateFrom).Days);

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Updated"
            };
        }
    }
}