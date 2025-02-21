using Microsoft.AspNetCore.Identity;

namespace SlamBackend.Models
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
