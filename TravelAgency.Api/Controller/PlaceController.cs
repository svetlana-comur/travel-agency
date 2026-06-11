using Microsoft.AspNetCore.Mvc;
using TravelAgency.BusinessLogic;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Place;

namespace TravelAgency.Api.Controller
{
    [Route("api/place")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlace _place;

        public PlaceController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _place = bl.GetPlaceActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_place.GetAllPlaces());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_place.GetPlaceById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlaceDto dto)
        {
            return Ok(_place.CreatePlace(dto));
        }

        [HttpPut]
        public IActionResult Update([FromBody] PlaceDto dto)
        {
            return Ok(_place.UpdatePlace(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_place.DeletePlace(id));
        }
    }
}