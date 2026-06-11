using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.Tour;

namespace TravelAgency.Api.Controller
{
    [Route("api/seed")]
    [ApiController]
    public class CategorySeedController : ControllerBase
    {
        private readonly TourContext _db = new TourContext();

        [HttpPost("categories")]
        public IActionResult SeedCategories()
        {
            if (_db.Categories.Any())
                return Ok("Already seeded");

            _db.Categories.AddRange(new[]
            {
            new CategoryData { Name = "Europe" },
            new CategoryData { Name = "Asia" },
            new CategoryData { Name = "America" },
            new CategoryData { Name = "Africa" }
        });

            _db.SaveChanges();
            return Ok("Categories seeded");
        }
    }
}
