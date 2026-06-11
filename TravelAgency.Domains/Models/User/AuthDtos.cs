namespace TravelAgency.Domains.Models.User
{
    public class ConfirmEmailDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }

    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}