using TravelAgency.Domains.Entities.User;

namespace TravelAgency.Domains.Entities.Hotel
{
    public class HotelBookingData
    {
        public int Id { get; set; }

        public int HotelId { get; set; }
        public HotelData Hotel { get; set; }

        public int UserId { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string Status { get; set; } = "Pending";

        public decimal TotalPrice { get; set; }
    }
}