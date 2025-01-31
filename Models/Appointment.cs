using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlamBackend.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime {  get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
