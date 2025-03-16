using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class PointsRepository : GenericRepository<Points>
    {
        public PointsRepository(BackendContext context) : base(context) { }
    }
}