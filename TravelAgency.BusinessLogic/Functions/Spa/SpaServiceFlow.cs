using TravelAgency.BusinessLogic.Core.Spa;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Spa;

namespace TravelAgency.BusinessLogic.Functions.Spa
{
    public class SpaServiceFlow : SpaServiceAction, ISpaService
    {
        public List<SpaServiceDto> GetAllSpaServicesAction()
            => ExecuteGetAll();

        public SpaServiceDto GetSpaServiceByIdAction(int id)
            => ExecuteGetById(id);

        public ResponceMsg CreateSpaServiceAction(SpaServiceDto dto)
            => ExecuteCreate(dto);

        public ResponceMsg UpdateSpaServiceAction(SpaServiceDto dto)
            => ExecuteUpdate(dto);

        public ResponceMsg DeleteSpaServiceAction(int id)
            => ExecuteDelete(id);
    }
}