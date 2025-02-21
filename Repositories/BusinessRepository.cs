using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class BusinessRepository : GenericRepository<Business>
    {
        public BusinessRepository(BackendContext context) : base(context) { }
    }
}