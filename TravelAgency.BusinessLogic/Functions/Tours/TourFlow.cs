using TravelAgency.BusinessLogic.Core.Tour;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Tour;

namespace TravelAgency.BusinessLogic.Functions.Tours
{
    public class TourFlow : TourAction, ITour
    {
        public List<TourDto> GetAllToursAction()
        {
            var tours = ExecuteGetAllToursAction();
            return tours;
        }

        public TourDto GetTourByIdAction(int id)
        {
            return GetTourDataByIdAction(id);
        }

        public ResponceMsg ResponceTourUpdateAction(TourDto tour)
        {
            return ExecuteTourUpdateAction(tour);
        }

        public ResponceMsg ResponceTourDeleteAction(int id)
        {
            return ExecuteTourDeleteAction(id);
        }

        public ResponceMsg ResponceTourCreateAction(TourDto tour)
        {
            return ExecuteTourCreateAction(tour);
        }
    }
}
