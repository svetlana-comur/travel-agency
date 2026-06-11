namespace TravelAgency.Domains.Entities.Hotel
{
    public class HotelRoomData
    {
        public int Id { get; set; }

        public int HotelId { get; set; }
        public HotelData Hotel { get; set; }

        public string RoomType { get; set; } // Single / Double / Suite

        public int Capacity { get; set; }

        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}