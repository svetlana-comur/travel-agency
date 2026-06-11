using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.BusinessLogic;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.Api.Controller
{
    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthActions _auth;

        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _auth = bl.GetAuthActions();
        }

        [HttpGet("status")]
        [AllowAnonymous]
        public IActionResult Status()
        {
            return Ok("Session is active");
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserAuthAction data)
        {
            var result = _auth.LoginActionFlow(data);

            if (!result.IsSuccess)
                return Unauthorized(result.Message);

            return Ok(new { token = result.Message });
        }

        [HttpPost("register-send-code")]
        [AllowAnonymous]
        public IActionResult RegisterSendCode([FromBody] string email)
        {
            var result = _auth.SendEmailConfirmationCode(email);
            return Ok(result);
        }

        [HttpPost("confirm-email")]
        [AllowAnonymous]
        public IActionResult ConfirmEmail([FromBody] ConfirmEmailDto dto)
        {
            var result = _auth.ConfirmEmail(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public IActionResult ForgotPassword([FromBody] string email)
        {
            var result = _auth.SendResetPasswordCode(email);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var result = _auth.ResetPassword(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}