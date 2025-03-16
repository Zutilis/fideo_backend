namespace Fideo.DTO
{
    public class AvailabelSlotCreateDTO
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int BusinessId { get; set; }
        public int OfferId { get; set; }
    }
}
