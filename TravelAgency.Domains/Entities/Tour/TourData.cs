using TravelAgency.Domains.Entities.Refs;
using TravelAgency.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domains.Entities.Tour;

namespace TravelAgency.Domains.Entities.Tour
{
    public class TourData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public TourDescriptionData? Description { get; set; }
        public CategoryData Category { get; set; }
        public List<TourImgData> Images { get; set; }
        public decimal Price { get; set; }
        public TourStatus Status { get; set; }
    }
}
