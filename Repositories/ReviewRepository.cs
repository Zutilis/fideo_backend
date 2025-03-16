using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class ReviewRepository : GenericRepository<Review>
    {
        public ReviewRepository(BackendContext context) : base(context) { }
    }
}