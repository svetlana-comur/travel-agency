using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TravelAgency.Api.Filters;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.User;

namespace TravelAgency.Api.Controller
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserContext _db = new UserContext();

        [HttpGet("getAll")]
        [AdminMod]
        public IActionResult GetAll()
        {
            return Ok(_db.Users.ToList());
        }

        [HttpPut]
        [AdminMod]
        public IActionResult Update(UserData dto)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == dto.Id);
            if (user == null) return NotFound();

            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.Contacts = dto.Contacts;
            user.DOB = dto.DOB;
            user.Gender = dto.Gender;
            user.Role = dto.Role;

            _db.SaveChanges();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        [AdminMod]
        public IActionResult Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            _db.Users.Remove(user);
            _db.SaveChanges();

            return Ok();
        }
    }
}
