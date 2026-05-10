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

        public TourDescriptionData? Description { get; set; }
        public int CategoryId { get; set; }
        public List<TourImgData> Images { get; set; }
        public decimal Price { get; set; }
    }
}
