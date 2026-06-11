using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Api.Filters;
using TravelAgency.BusinessLogic;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Booking;
using TravelAgency.Domains.Models.Hotel;

namespace TravelAgency.Api.Controller
{
    [Route("api/spa-booking")]
    [ApiController]
    [Authorize]
    public class SpaBookingController : ControllerBase
    {
        private readonly ISpaBooking _booking;

        public SpaBookingController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _booking = bl.GetSpaBookingActions();
        }

        [HttpPost]
        public IActionResult Create(SpaBookingDto dto)
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
        public IActionResult Update(SpaBookingDto dto)
        {
            return Ok(_booking.UpdateBookingAction(dto));
        }
    }
}