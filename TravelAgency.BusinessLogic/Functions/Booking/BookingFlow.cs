using TravelAgency.BusinessLogic.Core.Tour;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Tour;

namespace TravelAgency.BusinessLogic.Functions.Booking
{
    public class BookingFlow : BookingAction, IBooking
    {
        public ResponceMsg CreateBookingAction(TourBookingDto dto)
        {
            return ExecuteCreateBookingAction(dto);
        }

        public List<TourBookingDto> GetUserBookingsAction(int userId)
        {
            return ExecuteGetUserBookingsAction(userId);
        }

        public ResponceMsg CancelBookingAction(int bookingId)
        {
            return ExecuteCancelBookingAction(bookingId);
        }
    }
}