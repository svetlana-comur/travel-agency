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
    public class TourDescriptionData
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }
        public DescriptionAdvanced DescriptionAdvanced { get; set; }
    }
}
