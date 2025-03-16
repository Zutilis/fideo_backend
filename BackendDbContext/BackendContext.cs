
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fideo.Models;

namespace Fideo.CourseDbContext
{
    public class BackendContext : IdentityDbContext<User, Role, string>
    {
        public BackendContext(DbContextOptions<BackendContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Points>()
                .HasKey(p => new { p.UserId, p.BusinessId }); // Clé composite

            modelBuilder.Entity<Points>()
                .HasOne(p => p.User)
                .WithMany(u => u.Points) // Associer à la collection dans User
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Points>()
                .HasOne(p => p.Business)
                .WithMany(b => b.Points) // Associer à la collection dans Business
                .HasForeignKey(p => p.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);
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


