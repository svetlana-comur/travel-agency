namespace TravelAgency.Domains.Entities.Booking
{
    public class BookingData
    {
        public int Id { get; set; }

        public int BaseItemId { get; set; }

        public int UserId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }
    }
}