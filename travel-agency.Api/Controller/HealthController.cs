using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace travel_agency.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}
