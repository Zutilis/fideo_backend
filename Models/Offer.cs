using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlamBackend.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public double Price {  get; set; }
        public int Duration {  get; set; }

        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
