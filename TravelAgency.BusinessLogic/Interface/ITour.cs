using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Tour;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface ITour
    {
        List<TourDto> GetAllToursAction();
        TourDto GetTourByIdAction(int id);
        ResponceMsg ResponceTourUpdateAction(TourDto tour);
        ResponceMsg ResponceTourDeleteAction(int id);
        ResponceMsg ResponceTourCreateAction(TourDto tour);
    }
}
