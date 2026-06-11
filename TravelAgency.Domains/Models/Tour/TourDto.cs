using TravelAgency.Domains.Entities.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Domains.Models.Tour
{
    public class TourDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public List<string> Images { get; set; } = new();

        public decimal Price { get; set; }

        public string? Status { get; set; }
    }
}
