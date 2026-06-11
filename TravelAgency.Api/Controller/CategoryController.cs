using Microsoft.AspNetCore.Mvc;
using TravelAgency.DataAccess.Context;

namespace TravelAgency.Api.Controller
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            using var db = new TourContext();

            var categories = db.Categories
                .Select(c => new
                {
                    c.Id,
                    c.Name
                })
                .ToList();

            return Ok(categories);
        }
    }
}