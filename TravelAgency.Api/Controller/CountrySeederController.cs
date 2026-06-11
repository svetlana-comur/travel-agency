using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Place;

namespace TravelAgency.Api.Controller
{
    [Route("api/seed")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly PlaceContext _db = new PlaceContext();

        [HttpPost("countries")]
        public IActionResult SeedCountries()
        {
            if (_db.Countries.Any())
                return Ok("Already seeded");

            _db.Countries.AddRange(new[]
            {
            new CountryData { Name = "Moldova" },
            new CountryData { Name = "Ukraine" },
            new CountryData { Name = "Romania" },
            new CountryData { Name = "Germany" },
            new CountryData { Name = "Italy" }
        });

            _db.SaveChanges();
            return Ok("Countries seeded");
        }
    }
}
