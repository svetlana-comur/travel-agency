namespace TravelAgency.Domains.Entities.Spa
{
    public class SpaServiceImgData
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int SpaServiceId { get; set; }
        public SpaServiceData SpaService { get; set; }
    }
}