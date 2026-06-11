using TravelAgency.BusinessLogic.Core.Place;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Place;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Functions.Place
{
    public class PlaceFlow : PlaceAction, IPlace
    {
        public List<PlaceDto> GetAllPlaces() => ExecuteGetAll();
        public PlaceDto GetPlaceById(int id) => ExecuteGetById(id);
        public ResponceMsg CreatePlace(PlaceDto dto) => ExecuteCreate(dto);
        public ResponceMsg UpdatePlace(PlaceDto dto) => ExecuteUpdate(dto);
        public ResponceMsg DeletePlace(int id) => ExecuteDelete(id);
    }
}