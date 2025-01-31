using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class TeacherRepository
    {
        public readonly BackendContext _context;

        public TeacherRepository(BackendContext context)
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
