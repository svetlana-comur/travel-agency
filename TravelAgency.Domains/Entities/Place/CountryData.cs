namespace TravelAgency.Domains.Entities.Place
{
    public class CountryData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PlaceData> Places { get; set; } = new();
    }
}