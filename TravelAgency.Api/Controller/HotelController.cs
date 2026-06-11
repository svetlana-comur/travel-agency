using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Hotel;

namespace TravelAgency.Api.Controller
{
    [Route("api/hotel")]
    [ApiController]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _hotel = bl.GetHotelActions();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_hotel.GetAll());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            return Ok(_hotel.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] HotelDto dto)
        {
            return Ok(_hotel.Create(dto));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] HotelDto dto)
        {
            return Ok(_hotel.Update(dto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return Ok(_hotel.Delete(id));
        }
    }
}