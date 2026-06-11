using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Booking;

public interface ISpaBooking
{
    ResponceMsg CreateBookingAction(SpaBookingDto dto);
    List<SpaBookingDto> GetUserBookingsAction(int userId);
    List<SpaBookingDto> GetAllBookingsAction();
    ResponceMsg CancelBookingAction(int bookingId);
    ResponceMsg ConfirmBookingAction(int bookingId);

    ResponceMsg UpdateBookingAction(SpaBookingDto dto);
}