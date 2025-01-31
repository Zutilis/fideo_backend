using WebApplication1.CourseDbContext;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TeacherRepository
    {
        public readonly CourseContext _context;

        public TeacherRepository(CourseContext context)
        {
            _context = context;
        }

        public void CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }

        public List<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }
    }
}
