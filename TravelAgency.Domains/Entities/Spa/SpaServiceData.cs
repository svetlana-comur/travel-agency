namespace TravelAgency.Domains.Entities.Spa
{
    public class SpaServiceData
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int SpaSalonId { get; set; }
        public SpaSalonData SpaSalon { get; set; }

        public List<SpaServiceImgData> Images { get; set; } = new();
    }
}