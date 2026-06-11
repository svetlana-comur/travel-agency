using TravelAgency.BusinessLogic.Core.Spa;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Booking;

public class SpaBookingFlow : SpaBookingAction, ISpaBooking
{
    public ResponceMsg CreateBookingAction(SpaBookingDto dto)
        => ExecuteCreateBookingAction(dto);

    public List<SpaBookingDto> GetUserBookingsAction(int userId)
        => ExecuteGetUserBookingsAction(userId);

    public List<SpaBookingDto> GetAllBookingsAction()
        => ExecuteGetAllBookingsAction();

    public ResponceMsg CancelBookingAction(int bookingId)
        => ExecuteCancelBookingAction(bookingId);

    public ResponceMsg ConfirmBookingAction(int bookingId)
        => ExecuteConfirmBookingAction(bookingId);

    public ResponceMsg UpdateBookingAction(SpaBookingDto dto) 
        => ExecuteUpdateBookingAction(dto);
}