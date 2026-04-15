using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Tour;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgency.Api.Controller
{
    [Route("api/tour")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private ITour _tour;

        public TourController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _tour = bl.GetTourActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAllTours()
        {
            var tours = _tour.GetAllToursAction();
            return Ok(tours);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var tour = _tour.GetTourByIdAction(id);
            return Ok(tour);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TourDto tour)
        {
            var status = _tour.ResponceTourCreateAction(tour);
            return Ok(status);
        }

        [HttpPut]
        public IActionResult Update([FromBody] TourDto tour)
        {
            var status = _tour.ResponceTourUpdateAction(tour);
            return Ok(status);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var status = _tour.ResponceTourDeleteAction(id);
            return Ok(status);
        }
    }
}
