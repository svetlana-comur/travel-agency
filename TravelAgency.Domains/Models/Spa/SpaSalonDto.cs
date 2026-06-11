namespace TravelAgency.Domains.Models.Spa
{
    public class SpaSalonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        public List<SpaServiceDto> Services { get; set; } = new();
    }
}