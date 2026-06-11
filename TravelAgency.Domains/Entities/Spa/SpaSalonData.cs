namespace TravelAgency.Domains.Entities.Spa
{
    public class SpaSalonData
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        public List<SpaServiceData> Services { get; set; } = new();
        public List<SpaBookingData> Bookings { get; set; } = new();
    }
}