using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Hotel;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Hotel;

namespace TravelAgency.BusinessLogic.Core.Hotel
{
    public class HotelBookingAction
    {
        protected ResponceMsg ExecuteCreateBookingAction(HotelBookingDto dto)
        {
            using var db = new HotelContext();

            var hotel = db.Hotels.FirstOrDefault(x => x.Id == dto.HotelId);
            if (hotel == null)
                return new ResponceMsg { IsSuccess = false, Message = "Hotel not found" };

            var days = Math.Max(1, (dto.DateTo - dto.DateFrom).Days);

            var booking = new HotelBookingData
            {
                HotelId = dto.HotelId,
                UserId = dto.UserId,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                Status = "Pending",
                TotalPrice = hotel.BasePrice * days
            };

            db.HotelBookings.Add(booking);
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Created" };
        }

        protected List<HotelBookingDto> ExecuteGetUserBookingsAction(int userId)
        {
            using var db = new HotelContext();

            return db.HotelBookings
                .Where(x => x.UserId == userId)
                .Select(x => new HotelBookingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    HotelId = x.HotelId,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    Status = x.Status, 
                    TotalPrice = x.TotalPrice
                })
                .ToList();
        }

        protected List<HotelBookingDto> ExecuteGetAllBookingsAction()
        {
            using var db = new HotelContext();

            return db.HotelBookings
                .Select(x => new HotelBookingDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    HotelId = x.HotelId,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    Status = x.Status, 
                    TotalPrice = x.TotalPrice
                })
                .ToList();
        }

        protected ResponceMsg ExecuteCancelBookingAction(int id)
        {
            using var db = new HotelContext();

            var b = db.HotelBookings.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            b.Status = "Cancelled";
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Cancelled" };
        }

        protected ResponceMsg ExecuteConfirmBookingAction(int id)
        {
            using var db = new HotelContext();

            var b = db.HotelBookings.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return new ResponceMsg { IsSuccess = false, Message = "Not found" };

            b.Status = "Confirmed";
            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Confirmed" };
        }

        protected ResponceMsg ExecuteUpdateBookingAction(HotelBookingDto dto)
        {
            using var db = new HotelContext();

            var booking = db.HotelBookings
                .FirstOrDefault(x => x.Id == dto.Id);

            if (booking == null)
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Booking not found"
                };

            var hotel = db.Hotels
                .FirstOrDefault(x => x.Id == dto.HotelId);

            if (hotel == null)
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Hotel not found"
                };

            booking.UserId = dto.UserId;
            booking.HotelId = dto.HotelId;
            booking.DateFrom = dto.DateFrom;
            booking.DateTo = dto.DateTo;

            var days = Math.Max(1, (dto.DateTo - dto.DateFrom).Days);

            booking.TotalPrice = hotel.BasePrice * days;

            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Updated"
            };
        }
    }
}