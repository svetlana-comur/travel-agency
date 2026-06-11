using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domains.Entities.Core
{
    public class BaseItemData
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
        // "Spa", "Hotel", "Place", "Package"

        [Required]
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public List<ItemImageData> Images { get; set; } = new();
    }
}