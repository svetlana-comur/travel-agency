using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Api.Filters;
using TravelAgency.BusinessLogic;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Booking;

namespace TravelAgency.Api.Controller
{
    [Route("api/tour-booking")]
    [ApiController]
    [Authorize]
    
    public class TourBookingController : ControllerBase
    {
        private readonly ITourBooking _booking;

        public TourBookingController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _booking = bl.GetTourBookingActions();
        }

        [HttpPost]
        public IActionResult Create(TourBookingDto dto)
            => Ok(_booking.CreateBookingAction(dto));

        [HttpGet("user/{userId}")]
        public IActionResult GetUser(int userId)
            => Ok(_booking.GetUserBookingsAction(userId));

        [AdminMod]
        [HttpGet("all")]
        public IActionResult GetAll()
            => Ok(_booking.GetAllBookingsAction());

        [HttpPut("cancel/{id}")]
        public IActionResult Cancel(int id)
            => Ok(_booking.CancelBookingAction(id));

        [HttpPut("confirm/{id}")]
        public IActionResult Confirm(int id)
            => Ok(_booking.ConfirmBookingAction(id));

        [HttpPut]
        public IActionResult Update(TourBookingDto dto)
        {
            return Ok(_booking.UpdateBookingAction(dto));
        }
    }
}