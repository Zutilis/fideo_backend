using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>
    {
        public AppointmentRepository(BackendContext context) : base(context) { }
    }
}