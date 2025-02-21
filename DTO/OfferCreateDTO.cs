namespace SlamBackend.DTO
{
    public class OfferCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public int BusinessId { get; set; }
    }
}
