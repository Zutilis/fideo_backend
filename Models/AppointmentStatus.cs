using System.ComponentModel.DataAnnotations;

namespace Fideo.Models
{
    public class AppointmentStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
