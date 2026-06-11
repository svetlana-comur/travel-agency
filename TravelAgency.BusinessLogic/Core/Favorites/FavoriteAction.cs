using TravelAgency.DataAccess.Context;
using TravelAgency.Domains.Models.Base;

public class FavoriteAction
{
    protected ResponceMsg ExecuteAdd(FavoriteDto dto)
    {
        using var db = new UserContext(); 

        var fav = new FavoriteData
        {
            UserId = dto.UserId,
            ItemId = dto.ItemId,
            ItemType = dto.ItemType
        };

        db.Favorites.Add(fav);
        db.SaveChanges();

        return new ResponceMsg
        {
            IsSuccess = true,
            Message = "Added to favorites"
        };
    }

    protected List<FavoriteDto> ExecuteGet(int userId)
    {
        using var db = new UserContext();

        return db.Favorites
            .Where(x => x.UserId == userId)
            .Select(x => new FavoriteDto
            {
                Id = x.Id,
                UserId = x.UserId,
                ItemId = x.ItemId,
                ItemType = x.ItemType
            })
            .ToList();
    }

    protected ResponceMsg ExecuteRemove(int id)
    {
        using var db = new UserContext();

        var fav = db.Favorites.FirstOrDefault(x => x.Id == id);

        if (fav == null)
            return new ResponceMsg { IsSuccess = false, Message = "Not found" };

        db.Favorites.Remove(fav);
        db.SaveChanges();

        return new ResponceMsg
        {
            IsSuccess = true,
            Message = "Removed"
        };
    }
}