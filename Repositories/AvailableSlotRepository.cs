using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class AvailableSlotRepository : GenericRepository<AvailableSlot>
    {
        public AvailableSlotRepository(BackendContext context) : base(context) { }
    }
}