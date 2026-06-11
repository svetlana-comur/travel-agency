using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domains.Entities.Package
{
    public class PackageData
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortDescription { get; set; } 
        public string FullDescription { get; set; }

        public int DurationDays { get; set; }

        public decimal Price { get; set; }

        public List<PackageImgData> Images { get; set; } = new();
    }
}