using Microsoft.AspNetCore.Mvc;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Place;

namespace TravelAgency.Api.Controller
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            using var db = new PlaceContext();

            var data = db.Countries
                .Select(x => new {
                    x.Id,
                    x.Name
                })
                .ToList();

            return Ok(data);
        }
    }
}