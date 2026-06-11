namespace TravelAgency.Domains.Entities.Core
{
    public class ItemImageData
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int BaseItemId { get; set; }

        public BaseItemData BaseItem { get; set; }
    }
}