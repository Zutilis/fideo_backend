namespace Fideo.DTO
{
    public class ReviewCreateDTO
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AppointmentId { get; set; }
    }
}
