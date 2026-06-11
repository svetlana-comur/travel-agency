using Microsoft.AspNetCore.Mvc;
using TravelAgency.BusinessLogic;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Package;

namespace TravelAgency.Api.Controller
{
    [Route("api/package")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackage _package;

        public PackageController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _package = bl.GetPackageActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_package.GetAllPackages());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_package.GetPackageById(id));
        }

        [HttpPost]
        public IActionResult Create(PackageDto dto)
        {
            return Ok(_package.CreatePackage(dto));
        }

        [HttpPut]
        public IActionResult Update(PackageDto dto)
        {
            return Ok(_package.UpdatePackage(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_package.DeletePackage(id));
        }
    }
}