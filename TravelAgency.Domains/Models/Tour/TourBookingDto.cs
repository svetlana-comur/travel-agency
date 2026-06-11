namespace TravelAgency.Domains.Models.Tour
{
    public class TourBookingDto
    {
        public int TourId { get; set; }
        public int UserId { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}