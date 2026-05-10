using TravelAgency.BusinessLogic.Core.Auth;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponceAction LoginActionFlow(UserAuthAction auth)
        {
            var user = ValidateLoginExecution(auth);
            if (user == null)
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "Invalid username or password."
                };
            }

            var token = GenerateUserToken(user);

            return new ResponceAction
            {
                IsSuccess = true,
                Message = token,
                Id = user.Id
            };
        }
    }
}
