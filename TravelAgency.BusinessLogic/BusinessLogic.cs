using TravelAgency.BusinessLogic.Function.Auth;
using TravelAgency.BusinessLogic.Functions.Tours;
using TravelAgency.BusinessLogic.Interface;

namespace TravelAgency.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

        public ITour GetTourActions()
        {
            return new TourFlow();
        }
    }
}
