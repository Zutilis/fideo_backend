using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlamBackend.Models
{
    public class Points
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int BusinessId { get; set; }
        public Business Business { get; set; }

        public int Balance {  get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
