namespace Fideo.DTO
{
    public class AppointmentCreateDTO
    {
        public string UserId { get; set; }
        public int AvailableSlotId { get; set; }
        public int AppointmentStatusId { get; set; }
    }
}
