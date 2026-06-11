using TravelAgency.BusinessLogic.Structure;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.User;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        private readonly EmailService _emailService = new EmailService();

        internal UserData? ValidateLoginExecution(UserAuthAction data)
        {
            if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
                return null;

            var passwordHash = PasswordHasher.Hash(data.Password);

            using var db = new UserContext();

            return db.Users.FirstOrDefault(u =>
                (u.UserName == data.Login || u.Email == data.Login)
                && u.Password == passwordHash);
        }

        internal string GenerateUserToken(UserData user)
        {
            var token = new TokenService();
            return token.GenerateToken(user.Id, user.UserName, user.Role.ToString());
        }

        public ResponceMsg SendEmailConfirmationCode(string email)
        {
            var code = new Random().Next(100000, 999999).ToString();

            using var db = new UserContext();

            db.EmailTokens.Add(new EmailToken
            {
                Email = email,
                Token = code,
                Type = "confirm",
                ExpireAt = DateTime.UtcNow.AddMinutes(10),
                Used = false
            });

            db.SaveChanges();

            _emailService.Send(email, "Email confirmation", $"Code: {code}");

            return new ResponceMsg { IsSuccess = true };
        }

        public ResponceMsg SendResetPasswordCode(string email)
        {
            var code = new Random().Next(100000, 999999).ToString();

            using var db = new UserContext();

            db.EmailTokens.Add(new EmailToken
            {
                Email = email,
                Token = code,
                Type = "reset",
                ExpireAt = DateTime.UtcNow.AddMinutes(10),
                Used = false
            });

            db.SaveChanges();

            _emailService.Send(email, "Reset password", $"Code: {code}");

            return new ResponceMsg { IsSuccess = true };
        }

        internal ResponceMsg ExecuteConfirmEmail(string email, string code)
        {
            using var db = new UserContext();

            var token = db.EmailTokens.FirstOrDefault(x =>
                x.Email == email &&
                x.Token == code &&
                x.Type == "confirm" &&
                !x.Used &&
                x.ExpireAt > DateTime.UtcNow);

            if (token == null)
                return new ResponceMsg { IsSuccess = false, Message = "Invalid code" };

            var user = db.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
                return new ResponceMsg { IsSuccess = false, Message = "User not found" };

            token.Used = true;
            user.IsEmailConfirmed = true;

            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Email confirmed" };
        }

        internal ResponceMsg ExecuteResetPassword(string email, string code, string newPassword)
        {
            using var db = new UserContext();

            var token = db.EmailTokens.FirstOrDefault(x =>
                x.Email == email &&
                x.Token == code &&
                x.Type == "reset" &&
                !x.Used &&
                x.ExpireAt > DateTime.UtcNow);

            if (token == null)
                return new ResponceMsg { IsSuccess = false, Message = "Invalid code" };

            var user = db.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
                return new ResponceMsg { IsSuccess = false, Message = "User not found" };

            user.Password = PasswordHasher.Hash(newPassword);
            token.Used = true;

            db.SaveChanges();

            return new ResponceMsg { IsSuccess = true, Message = "Password updated" };
        }
    }
}