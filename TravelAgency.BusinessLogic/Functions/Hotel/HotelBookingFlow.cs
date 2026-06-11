using TravelAgency.BusinessLogic.Core.Hotel;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Hotel;

public class HotelBookingFlow : HotelBookingAction, IHotelBooking
{
    public ResponceMsg CreateBookingAction(HotelBookingDto dto)
        => ExecuteCreateBookingAction(dto);

    public List<HotelBookingDto> GetUserBookingsAction(int userId)
        => ExecuteGetUserBookingsAction(userId);

    public List<HotelBookingDto> GetAllBookingsAction()
        => ExecuteGetAllBookingsAction();

    public ResponceMsg CancelBookingAction(int bookingId)
        => ExecuteCancelBookingAction(bookingId);

    public ResponceMsg ConfirmBookingAction(int bookingId)
        => ExecuteConfirmBookingAction(bookingId);

    public ResponceMsg UpdateBookingAction(HotelBookingDto dto) 
        => ExecuteUpdateBookingAction(dto);
}