namespace TravelAgency.Domains.Entities.Package
{
    public class PackageImgData
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int PackageId { get; set; }
        public PackageData Package { get; set; }
    }
}