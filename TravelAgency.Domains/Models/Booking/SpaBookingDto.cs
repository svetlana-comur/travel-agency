namespace TravelAgency.Domains.Models.Booking
{
    public class SpaBookingDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int SpaSalonId { get; set; }

        public DateTime Date { get; set; }
        public string Time { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }
    }
}