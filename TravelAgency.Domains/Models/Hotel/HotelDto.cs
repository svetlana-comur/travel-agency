namespace TravelAgency.Domains.Models.Hotel
{
    public class HotelDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        public decimal Rating { get; set; }
        public string Phone { get; set; }

        public decimal BasePrice { get; set; }

        public List<string> Images { get; set; } = new();
    }
}