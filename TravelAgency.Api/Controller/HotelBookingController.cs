using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Api.Filters;
using TravelAgency.BusinessLogic;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Hotel;

namespace TravelAgency.Api.Controller
{
    [Route("api/hotel-booking")]
    [ApiController]
    [Authorize]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBooking _booking;

        public HotelBookingController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _booking = bl.GetHotelBookingActions();
        }

        [HttpPost]
        public IActionResult Create(HotelBookingDto dto)
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
        public IActionResult Update(HotelBookingDto dto)
        {
            return Ok(_booking.UpdateBookingAction(dto));
        }
    }
}