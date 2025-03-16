using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class BusinessRepository : GenericRepository<Business>
    {
        public BusinessRepository(BackendContext context) : base(context) { }
    }
}