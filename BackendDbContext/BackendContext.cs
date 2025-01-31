
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SlamBackend.Models;

namespace SlamBackend.CourseDbContext
{
    public class BackendContext : IdentityDbContext<User, Role, string>
    {
        public BackendContext(DbContextOptions<BackendContext> options) : base(options) 
        {

        }
    }
}


