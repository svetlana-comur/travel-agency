namespace TravelAgency.Domains.Models.Place
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }

        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public List<string> Images { get; set; } = new();
    }
}