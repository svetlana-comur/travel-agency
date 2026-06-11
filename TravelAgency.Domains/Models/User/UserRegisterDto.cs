using TravelAgency.Domains.Enums;

namespace TravelAgency.Domains.Models.User
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contacts { get; set; }
        public DateTime DOB { get; set; } = DateTime.Now;
        public GenderTypes Gender { get; set; }
    }
}
