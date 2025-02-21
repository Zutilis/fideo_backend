
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

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatus { get; set; }
        public DbSet<AvailableSlot> AvailableSlots { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}


