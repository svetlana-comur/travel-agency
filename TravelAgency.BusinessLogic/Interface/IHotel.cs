using TravelAgency.Domains.Models.Hotel;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface IHotel
    {
        List<HotelDto> GetAll();
        HotelDto GetById(int id);

        ResponceMsg Create(HotelDto dto);
        ResponceMsg Update(HotelDto dto);
        ResponceMsg Delete(int id);
    }
}