using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class CourseRepository
    {
        public readonly BackendContext _context;

        public CourseRepository(BackendContext context)
        {
            _context = context;
        }

        public void CreateCourse(Business course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Business course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public List<Business> GetCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
