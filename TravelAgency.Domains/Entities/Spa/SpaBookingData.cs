using TravelAgency.Domains.Entities.User;

namespace TravelAgency.Domains.Entities.Spa
{
    public class SpaBookingData
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int SpaSalonId { get; set; }
        public SpaSalonData? SpaSalon { get; set; }

        public DateTime Date { get; set; }
        public string Time { get; set; }

        public string Status { get; set; } = "Pending";

        public decimal TotalPrice { get; set; }
    }
}