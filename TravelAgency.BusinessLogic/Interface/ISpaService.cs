using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Spa;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface ISpaService
    {
        List<SpaServiceDto> GetAllSpaServicesAction();
        SpaServiceDto GetSpaServiceByIdAction(int id);

        ResponceMsg CreateSpaServiceAction(SpaServiceDto dto);
        ResponceMsg UpdateSpaServiceAction(SpaServiceDto dto);
        ResponceMsg DeleteSpaServiceAction(int id);
    }
}