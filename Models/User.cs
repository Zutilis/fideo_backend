using Microsoft.AspNetCore.Identity;

namespace SlamBackend.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<LoyaltyPoints> LoyaltyPoints { get; set; }
    }
}
