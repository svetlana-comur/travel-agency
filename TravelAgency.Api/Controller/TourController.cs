using TravelAgency.Api.Filters;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Tour;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgency.Api.Controller
{
    [Route("api/tour")]
    [ApiController]
    [Authorize]
    public class TourController : ControllerBase
    {
        private readonly ITour _tour;

        public TourController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _tour = bl.GetTourActions();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAllTours()
        {
            return Ok(_tour.GetAllToursAction());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_tour.GetTourByIdAction(id));
        }

        [AdminMod]
        [HttpPost]
        public IActionResult Create([FromBody] TourDto tour)
        {
            var status = _tour.ResponceTourCreateAction(tour);
            return Ok(status);
        }

        [AdminMod]
        [HttpPut]
        public IActionResult Update([FromBody] TourDto tour)
        {
            var status = _tour.ResponceTourUpdateAction(tour);
            return Ok(status);
        }

        [AdminMod]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var status = _tour.ResponceTourDeleteAction(id);
            return Ok(status);
        }
    }
}