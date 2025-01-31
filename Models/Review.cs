using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlamBackend.Models
{
    public class Review
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }

        public int Rating {  get; set; }
        public string Comment {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
