using TravelAgency.BusinessLogic.Functions.Auth;
using TravelAgency.BusinessLogic.Functions.Hotel;
using TravelAgency.BusinessLogic.Functions.Package;
using TravelAgency.BusinessLogic.Functions.Place;
using TravelAgency.BusinessLogic.Functions.Spa;
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

        public IRegisterActions GetRegisterActions()
        {
            return new RegisterFlow();
        }

        public ITour GetTourActions()
        {
            return new TourFlow();
        }

        public ISpa GetSpaActions()
        {
            return new SpaFlow();
        }

        public ISpaBooking GetSpaBookingActions()
        {
            return new SpaBookingFlow();
        }

        public IHotel GetHotelActions()
        {
            return new HotelFlow();
        }
        public ITourBooking GetTourBookingActions()
        {
            return new TourBookingFlow();
        }

        public IHotelBooking GetHotelBookingActions()
        {
            return new HotelBookingFlow();
        }

        public ISpaService GetSpaServiceActions()
        {
            return new SpaServiceFlow();
        }

        public IPlace GetPlaceActions()
        {
            return new PlaceFlow();
        }

        public IPackage GetPackageActions()
        {
            return new PackageFlow();
        }

        public IFavorite GetFavoriteActions()
        {
            return new FavoriteFlow();
        }
    }
}
