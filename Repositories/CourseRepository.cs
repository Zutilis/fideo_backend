using WebApplication1.CourseDbContext;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CourseRepository
    {
        public readonly CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
