namespace TravelAgency.Domains.Models.Hotel
{
    public class HotelBookingDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int HotelId { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }
    }
}