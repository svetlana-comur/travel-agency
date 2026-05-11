using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.User;
using TravelAgency.BusinessLogic.Core.Auth;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Functions.Auth
{
    public class RegisterFlow : RegisterActions, IRegisterActions
    {
        public ResponceAction RegisterActionFlow(UserRegisterDto uReg)
        {
            return RegisterUserExecution(uReg);
        }
    }
}
