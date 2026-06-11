using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Api.Filters;
using TravelAgency.BusinessLogic;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Spa;

namespace TravelAgency.Api.Controller
{
    [Route("api/spa-service")]
    [ApiController]
    [Authorize]
    public class SpaServiceController : ControllerBase
    {
        private readonly ISpaService _service;

        public SpaServiceController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _service = bl.GetSpaServiceActions();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAll()
            => Ok(_service.GetAllSpaServicesAction());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
            => Ok(_service.GetSpaServiceByIdAction(id));

        [AdminMod]
        [HttpPost]
        public IActionResult Create(SpaServiceDto dto)
            => Ok(_service.CreateSpaServiceAction(dto));

        [AdminMod]
        [HttpPut]
        public IActionResult Update(SpaServiceDto dto)
            => Ok(_service.UpdateSpaServiceAction(dto));

        [AdminMod]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_service.DeleteSpaServiceAction(id));
    }
}