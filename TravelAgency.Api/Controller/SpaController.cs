using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Api.Filters;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Spa;

namespace TravelAgency.Api.Controller
{
    [Route("api/spa")]
    [ApiController]
    [Authorize]
    public class SpaController : ControllerBase
    {
        private readonly ISpa _spa;

        public SpaController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _spa = bl.GetSpaActions();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_spa.GetAllSpaAction());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            return Ok(_spa.GetSpaByIdAction(id));
        }

        [AdminMod]
        [HttpPost]
        public IActionResult Create([FromBody] SpaSalonDto dto)
        {
            return Ok(_spa.CreateSpaAction(dto));
        }

        [AdminMod]
        [HttpPut]
        public IActionResult Update([FromBody] SpaSalonDto dto)
        {
            return Ok(_spa.UpdateSpaAction(dto));
        }

        [AdminMod]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_spa.DeleteSpaAction(id));
        }
    }
}