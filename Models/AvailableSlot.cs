using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlamBackend.Models
{
    public class AvailableSlot
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDateTime;
        public DateTime EndDateTime;

        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }

        public int OfferId { get; set; }
        [ForeignKey("OfferId")]
        public Offer Offer { get; set; }
    }
}
