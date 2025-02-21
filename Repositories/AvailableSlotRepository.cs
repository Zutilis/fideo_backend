using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class AvailableSlotRepository : GenericRepository<AvailableSlot>
    {
        public AvailableSlotRepository(BackendContext context) : base(context) { }
    }
}