using TravelAgency.Domains.Entities.User;

public class FavoriteData
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public string ItemType { get; set; }
    // "Tour", "SpaService", "Hotel", "Package"
}