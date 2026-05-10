using TravelAgency.BusinessLogic.Structure;
using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Entities.User;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        internal UserData? ValidateLoginExecution(UserAuthAction data)
        {
            if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
                return null;

            var passwordHash = PasswordHasher.Hash(data.Password);

            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(
                    u => (u.UserName == data.Login || u.Email == data.Login)
                         && u.Password == passwordHash);
            }
        }

        internal string GenerateUserToken(UserData user)
        {
            var token = new TokenService();
            return token.GenerateToken(user.Id, user.UserName, user.Role.ToString());
        }
    }
}
