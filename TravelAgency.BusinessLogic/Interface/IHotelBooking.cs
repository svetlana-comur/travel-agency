using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Hotel;

public interface IHotelBooking
{
    ResponceMsg CreateBookingAction(HotelBookingDto dto);
    List<HotelBookingDto> GetUserBookingsAction(int userId);
    List<HotelBookingDto> GetAllBookingsAction();
    ResponceMsg CancelBookingAction(int bookingId);
    ResponceMsg ConfirmBookingAction(int bookingId);

    ResponceMsg UpdateBookingAction(HotelBookingDto dto);
}