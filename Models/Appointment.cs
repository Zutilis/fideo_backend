using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fideo.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        public int AvailableSlotId { get; set; }
        [ForeignKey("AvailableSlotId")]
        public AvailableSlot AvailableSlot { get; set; }

        public int AppointmentStatusId { get; set; }
        [ForeignKey("AppointmentStatusId")]
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
