using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class AppointmentStatusRepository : GenericRepository<AppointmentStatus>
    {
        public AppointmentStatusRepository(BackendContext context) : base(context) { }
    }
}