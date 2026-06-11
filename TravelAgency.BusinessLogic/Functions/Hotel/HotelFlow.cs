using TravelAgency.BusinessLogic.Core.Hotel;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Hotel;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Functions.Hotel
{
    public class HotelFlow : HotelAction, IHotel
    {
        public List<HotelDto> GetAll() => ExecuteGetAll();

        public HotelDto GetById(int id) => ExecuteGetById(id);

        public ResponceMsg Create(HotelDto dto) => ExecuteCreate(dto);

        public ResponceMsg Update(HotelDto dto) => ExecuteUpdate(dto);

        public ResponceMsg Delete(int id) => ExecuteDelete(id);
    }
}