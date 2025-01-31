using WebApplication1.CourseDbContext;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SubjectRepository
    {
        public readonly CourseContext _context;

        public SubjectRepository(CourseContext context)
        {
            _context = context;
        }

        public void CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public List<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }
    }
}
