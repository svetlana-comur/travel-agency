using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.Api.Controller
{
    [Route("api/reg")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterActions _userReg;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _userReg = bl.GetRegisterActions();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegisterDto uRegData)
        {
            var result = _userReg.RegisterActionFlow(uRegData);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(new
            {
                id = result.Id,
                message = result.Message
            });
        }
    }
}