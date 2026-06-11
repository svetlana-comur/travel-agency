using TravelAgency.Domains.Models.Place;
using TravelAgency.Domains.Models.Base;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface IPlace
    {
        List<PlaceDto> GetAllPlaces();
        PlaceDto GetPlaceById(int id);

        ResponceMsg CreatePlace(PlaceDto dto);
        ResponceMsg UpdatePlace(PlaceDto dto);
        ResponceMsg DeletePlace(int id);
    }
}