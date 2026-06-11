using TravelAgency.Domains.Models.Base;

public interface IFavorite
{
    ResponceMsg AddFavorite(FavoriteDto dto);
    ResponceMsg RemoveFavorite(int id);

    List<FavoriteDto> GetUserFavorites(int userId);
}