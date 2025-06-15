using Microsoft.AspNetCore.Identity;

namespace Fideo.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Points> Points { get; set; }
    }
}
