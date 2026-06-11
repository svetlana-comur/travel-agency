using TravelAgency.Domains.Entities.Tour;
using TravelAgency.Domains.Entities.User;

namespace TravelAgency.Domains.Entities.Tour
{
    public class TourBookingData
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TourId { get; set; }
        public TourData? Tour { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string Status { get; set; } = "Pending";

        public decimal TotalPrice { get; set; }

        public string? FullName { get; set; }
        public string? DepartureCity { get; set; }
        public int Guests { get; set; }
        public string? PaymentMethod { get; set; }
    }
}