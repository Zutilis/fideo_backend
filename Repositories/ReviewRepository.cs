using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class ReviewRepository : GenericRepository<Review>
    {
        public ReviewRepository(BackendContext context) : base(context) { }
    }
}