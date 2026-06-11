using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domains.Entities.Hotel
{
    public class HotelData
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public decimal Rating { get; set; }

        public string Phone { get; set; }

        public decimal BasePrice { get; set; }

        public List<HotelImgData> Images { get; set; } = new();

        public List<HotelRoomData> Rooms { get; set; } = new();
    }
}