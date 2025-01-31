using WebApplication1.CourseDbContext;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AuthRepository
    {
        public readonly CourseContext _context;

        public AuthRepository(CourseContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
