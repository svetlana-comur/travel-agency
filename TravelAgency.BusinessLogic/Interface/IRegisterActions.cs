using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface IRegisterActions
    {
        ResponceAction RegisterActionFlow(UserRegisterDto uReg);
    }
}
