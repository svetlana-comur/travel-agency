using TravelAgency.BusinessLogic.Interface;
using TravelAgency.BusinessLogic.Functions.Auth;
using TravelAgency.BusinessLogic.Functions.Tours;

namespace TravelAgency.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

        public IRegisterActions GetRegisterActions()
        {
            return new RegisterFlow();
        }

        public ITour GetTourActions()
        {
            return new TourFlow();
        }


    }
}
