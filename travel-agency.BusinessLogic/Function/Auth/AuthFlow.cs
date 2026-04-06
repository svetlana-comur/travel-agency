using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_agency.BusinessLogic.Core.Auth;

namespace travel_agency.BusinessLogic.Function.Auth
{
    internal class AuthFlow : AuthActions, IAuthActions
    {
        public object? LoginActionFlow(UserAuthAction auth)
        {
            var isValid = ValidateLogin(auth);
            return isValid ? GenToken(auth) : null;
        }
    }
}
