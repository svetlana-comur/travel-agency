using TravelAgency.Domains.Models.Base;

public interface ITourBooking
{
    ResponceMsg CreateBookingAction(TourBookingDto dto);
    List<TourBookingDto> GetUserBookingsAction(int userId);
    List<TourBookingDto> GetAllBookingsAction();
    ResponceMsg CancelBookingAction(int bookingId);
    ResponceMsg ConfirmBookingAction(int bookingId);

    ResponceMsg UpdateBookingAction(TourBookingDto dto);
}