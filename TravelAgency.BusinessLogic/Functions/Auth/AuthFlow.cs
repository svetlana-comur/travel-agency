using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BusinessLogic.Core.Auth;
using TravelAgency.BusinessLogic.Interface; 
using TravelAgency.Domains.Models.User; 

namespace TravelAgency.BusinessLogic.Function.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public object? LoginActionFlow(UserAuthAction auth)
        {
            var isValid = ValidateLogin(auth);
            return isValid ? GenToken(auth) : null;
        }
    }
}
