namespace SlamBackend.DTO
{
    public class AppointmentCreateDTO
    {
        public int UserId { get; set; }
        public int AvailableSlotId { get; set; }
        public int AppointmentStatusId { get; set; }
    }
}
