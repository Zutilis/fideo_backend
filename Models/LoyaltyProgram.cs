using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlamBackend.Models
{
    public class LoyaltyProgram
    {
        [Key]
        public int Id { get; set; }
        public int PointsPerEuro {  get; set; }
        public int DiscountTreshold {  get; set; }
        public double DiscountValue {  get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
