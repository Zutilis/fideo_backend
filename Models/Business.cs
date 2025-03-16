using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fideo.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public int PointsPerEuro {  get; set; }
        public int DiscountTreshold {  get; set; }
        public double DiscountValue {  get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Points> Points { get; set; }

        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
    }
}
