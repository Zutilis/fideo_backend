using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class AppointmentStatusRepository : GenericRepository<AppointmentStatus>
    {
        public AppointmentStatusRepository(BackendContext context) : base(context) { }
    }
}