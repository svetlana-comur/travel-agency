using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Tour;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface IBooking
    {
        ResponceMsg CreateBookingAction(TourBookingDto dto);

        List<TourBookingDto> GetUserBookingsAction(int userId);

        ResponceMsg CancelBookingAction(int bookingId);
    }
}