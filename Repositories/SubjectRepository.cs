using SlamBackend.CourseDbContext;
using SlamBackend.Models;

namespace SlamBackend.Repositories
{
    public class SubjectRepository
    {
        public readonly BackendContext _context;

        public SubjectRepository(BackendContext context)
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
