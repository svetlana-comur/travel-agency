using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Spa;
using TravelAgency.Domains.Models.Booking;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface ISpa
    {
        List<SpaSalonDto> GetAllSpaAction();
        SpaSalonDto GetSpaByIdAction(int id);

        ResponceMsg CreateSpaAction(SpaSalonDto dto);
        ResponceMsg UpdateSpaAction(SpaSalonDto dto);
        ResponceMsg DeleteSpaAction(int id);

    }
}