namespace TravelAgency.Domains.Models.Spa
{
    public class SpaServiceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int SpaSalonId { get; set; }

        public List<string> Images { get; set; } = new();
    }
}