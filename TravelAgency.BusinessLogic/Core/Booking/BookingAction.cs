using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Tour;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Tour;

namespace TravelAgency.BusinessLogic.Core.Tour
{
    public class BookingAction
    {
        protected ResponceMsg ExecuteCreateBookingAction(TourBookingDto dto)
        {
            using var db = new TourContext();

            var tour = db.Tours.FirstOrDefault(x => x.Id == dto.TourId);
            if (tour == null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Tour not found"
                };
            }

            var overlap = db.TourBookings.Any(b =>
                b.TourId == dto.TourId &&
                (
                    (dto.DateFrom >= b.DateFrom && dto.DateFrom <= b.DateTo) ||
                    (dto.DateTo >= b.DateFrom && dto.DateTo <= b.DateTo)
                )
            );

            if (overlap)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Tour already booked for selected dates"
                };
            }

            var days = (dto.DateTo - dto.DateFrom).Days;
            if (days <= 0) days = 1;

            var totalPrice = tour.Price * days;

            var booking = new TourBookingData
            {
                TourId = dto.TourId,
                UserId = dto.UserId,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                Status = "Pending",
                TotalPrice = totalPrice
            };

            db.TourBookings.Add(booking);
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Booking created successfully"
            };
        }

        protected List<TourBookingDto> ExecuteGetUserBookingsAction(int userId)
        {
            using var db = new TourContext();

            return db.TourBookings
                .Include(x => x.Tour)
                .Where(x => x.UserId == userId)
                .Select(x => new TourBookingDto
                {
                    TourId = x.TourId,
                    UserId = x.UserId,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo
                })
                .ToList();
        }

        protected ResponceMsg ExecuteCancelBookingAction(int bookingId)
        {
            using var db = new TourContext();

            var booking = db.TourBookings.FirstOrDefault(x => x.Id == bookingId);

            if (booking == null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false,
                    Message = "Booking not found"
                };
            }

            booking.Status = "Cancelled";
            db.SaveChanges();

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Booking cancelled"
            };
        }
    }
}