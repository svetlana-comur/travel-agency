namespace TravelAgency.Domains.Entities.Hotel
{
    public class HotelImgData
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int HotelId { get; set; }
        public HotelData Hotel { get; set; }
    }
}