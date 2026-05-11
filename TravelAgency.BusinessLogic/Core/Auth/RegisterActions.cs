using TravelAgency.BusinessLogic.Structure;
using TravelAgency.Domains.Models.User;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.User;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Core.Auth
{
    public class RegisterActions
    {
        internal ResponceAction RegisterUserExecution(UserRegisterDto uReg)
        {
            if (string.IsNullOrEmpty(uReg.UserName) ||
                string.IsNullOrEmpty(uReg.Password) ||
                string.IsNullOrEmpty(uReg.Email))
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "UserName, Password and Email are required."
                };
            }

            UserData? existing;
            using (var db = new UserContext())
            {
                existing = db.Users.FirstOrDefault(
                    u => u.Email == uReg.Email || u.UserName == uReg.UserName);
            }

            if (existing != null)
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "Email or username already exists."
                };
            }

            var user = new UserData
            {
                UserName = uReg.UserName,
                Password = PasswordHasher.Hash(uReg.Password),
                Email = uReg.Email,
                Contacts = uReg.Contacts ?? string.Empty,
                DOB = uReg.DOB,
                Gender = uReg.Gender,
                Role = UserRole.User
            };

            using (var db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return new ResponceAction
            {
                IsSuccess = true,
                Message = "User registration successful.",
                Id = user.Id
            };
        }
    }
}
