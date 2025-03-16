using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class OfferRepository : GenericRepository<Offer>
    {
        public OfferRepository(BackendContext context) : base(context) { }
    }
}