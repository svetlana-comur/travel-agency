using TravelAgency.Domains.Models.Base;

public class FavoriteFlow : FavoriteAction, IFavorite
{
    public ResponceMsg AddFavorite(FavoriteDto dto)
        => ExecuteAdd(dto);

    public List<FavoriteDto> GetUserFavorites(int userId)
        => ExecuteGet(userId);

    public ResponceMsg RemoveFavorite(int id)
        => ExecuteRemove(id);
}