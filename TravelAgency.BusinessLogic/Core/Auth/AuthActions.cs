using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BusinessLogic.Core.Auth
{
    internal class AuthActions
    {
        internal bool ValidateLogin(UserAuthAction data)
        {
            UserData? local;
            using (var db = new UserContext())
            {
                local = db.Users.FirstOrDefault(
                        u => u.UserName == data.Login
                             && u.Password == data.Password);
            }


            if (string.IsNullOrEmpty(data.Login) && string.IsNullOrEmpty(data.Password))
                return false;
            return true;
        }

        internal string? GenToken(UserAuthAction data)
        {
            return "TOKEN";
        }
    }
}
