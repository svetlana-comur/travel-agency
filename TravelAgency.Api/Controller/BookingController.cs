using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Tour;

namespace TravelAgency.Api.Controller
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBooking _booking;

        public BookingController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _booking = bl.GetBookingFlow();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] TourBookingDto dto)
        {
            var result = _booking.CreateBookingAction(dto);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public IActionResult GetUserBookings(int userId)
        {
            var result = _booking.GetUserBookingsAction(userId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Cancel(int id)
        {
            var result = _booking.CancelBookingAction(id);
            return Ok(result);
        }
    }
}