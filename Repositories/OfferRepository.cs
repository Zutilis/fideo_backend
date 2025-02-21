using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class OfferRepository : GenericRepository<Offer>
    {
        public OfferRepository(BackendContext context) : base(context) { }
    }
}