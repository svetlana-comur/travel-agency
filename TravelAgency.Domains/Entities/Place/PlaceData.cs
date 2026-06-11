namespace TravelAgency.Domains.Entities.Place
{
    public class PlaceData
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }   
        public string FullDescription { get; set; }

        public decimal Price { get; set; }

        public int CountryId { get; set; }
        public CountryData Country { get; set; }

        public List<PlaceImgData> Images { get; set; } = new();
    }
}