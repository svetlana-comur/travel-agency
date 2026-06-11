using TravelAgency.BusinessLogic.Core.Tours;
using TravelAgency.Domains.Models.Base;

public class TourBookingFlow : TourBookingAction, ITourBooking
{
    public ResponceMsg CreateBookingAction(TourBookingDto dto)
        => ExecuteCreateBookingAction(dto);

    public List<TourBookingDto> GetUserBookingsAction(int userId)
        => ExecuteGetUserBookingsAction(userId);

    public List<TourBookingDto> GetAllBookingsAction()
        => ExecuteGetAllBookingsAction();

    public ResponceMsg CancelBookingAction(int bookingId)
        => ExecuteCancelBookingAction(bookingId);

    public ResponceMsg ConfirmBookingAction(int bookingId)
        => ExecuteConfirmBookingAction(bookingId);

    public ResponceMsg UpdateBookingAction(TourBookingDto dto) 
        => ExecuteUpdateBookingAction(dto);
}