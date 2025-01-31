using System.ComponentModel.DataAnnotations;

namespace SlamBackend.Models
{
    public class AppointmentStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
