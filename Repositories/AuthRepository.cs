using Fideo.CourseDbContext;
using Fideo.Models;

namespace Fideo.Repositories
{
    public class AuthRepository
    {
        public readonly BackendContext _context;

        public AuthRepository(BackendContext context)
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
