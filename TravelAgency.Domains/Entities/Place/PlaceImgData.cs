namespace TravelAgency.Domains.Entities.Place
{
    public class PlaceImgData
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int PlaceId { get; set; }
        public PlaceData Place { get; set; }
    }
}