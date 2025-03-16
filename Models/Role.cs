using Microsoft.AspNetCore.Identity;

namespace Fideo.Models
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
