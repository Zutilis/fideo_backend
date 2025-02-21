using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class PointsRepository : GenericRepository<Points>
    {
        public PointsRepository(BackendContext context) : base(context) { }
    }
}