using TravelAgency.BusinessLogic.Core.Spa;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.Spa;
using System.Collections.Generic;

namespace TravelAgency.BusinessLogic.Functions.Spa
{
    public class SpaFlow : SpaAction, ISpa
    {
        public List<SpaSalonDto> GetAllSpaAction()
        {
            return ExecuteGetAll();
        }

        public SpaSalonDto GetSpaByIdAction(int id)
        {
            return ExecuteGetById(id);
        }

        public ResponceMsg CreateSpaAction(SpaSalonDto dto)
        {
            return ExecuteCreate(dto);
        }

        public ResponceMsg UpdateSpaAction(SpaSalonDto dto)
        {
            return ExecuteUpdate(dto);
        }

        public ResponceMsg DeleteSpaAction(int id)
        {
            return ExecuteDelete(id);
        }
    }
}