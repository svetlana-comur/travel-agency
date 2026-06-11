namespace TravelAgency.Domains.Models.Package
{
    public class PackageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; } 
        public string FullDescription { get; set; }

        public int DurationDays { get; set; }

        public decimal Price { get; set; }

        public List<string> Images { get; set; } = new();
    }
}