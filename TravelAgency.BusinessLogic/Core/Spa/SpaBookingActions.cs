using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Spa;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Booking;

namespace TravelAgency.BusinessLogic.Core.Spa
{
    public class SpaBookingAction
    {
        protected ResponceMsg ExecuteCreateBookingAction(SpaBookingDto dto)
        {
            using var db = new SpaContext();

            var spa = db.SpaSalons.FirstOrDefault(x => x.Id == dto.SpaSalonId);
            if (spa == null)
                return new ResponceMsg { IsSuccess = false, Message = "Spa not found" };

            var booking = new SpaBookingData
            {
                UserId = dto.UserId,
                SpaSalonId = dto.SpaSalonId,
                Date = dto.Date,
                Time = dto.Time,
                Status = "Pending"
            };

            db.SpaBookings.Add(booking);
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Created" };
        }

        protected List<SpaBookingDto> ExecuteGetUserBookingsAction(int userId)
        {
            using var db = new SpaContext();

            return db.SpaBookings
                .Where(x => x.UserId == userId)
                .Select(x => new SpaBookingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    SpaSalonId = x.SpaSalonId,
                    Date = x.Date,
                    Time = x.Time,
                    Status = x.Status
                })
                .ToList();
        }

        protected List<SpaBookingDto> ExecuteGetAllBookingsAction()
        {
            using var db = new SpaContext();

            return db.SpaBookings
                .Select(x => new SpaBookingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    SpaSalonId = x.SpaSalonId,
                    Date = x.Date,
                    Time = x.Time,
                    Status = x.Status
                })
                .ToList();
        }

        protected ResponceMsg ExecuteCancelBookingAction(int id)
        {
            using var db = new SpaContext();

            var b = db.SpaBookings.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            b.Status = "Cancelled";
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Cancelled" };
        }

        protected ResponceMsg ExecuteConfirmBookingAction(int id)
        {
            using var db = new SpaContext();

            var b = db.SpaBookings.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            b.Status = "Confirmed";
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Confirmed" };
        }

        protected ResponceMsg ExecuteUpdateBookingAction(SpaBookingDto dto)
        {
            using var db = new SpaContext();

            var booking = db.SpaBookings
                .FirstOrDefault(x => x.Id == dto.Id);

            if (booking == null)
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Booking not found"
                };

            booking.UserId = dto.UserId;
            booking.SpaSalonId = dto.SpaSalonId;
            booking.Date = dto.Date;
            booking.Time = dto.Time;

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Updated"
            };
        }
    }
}