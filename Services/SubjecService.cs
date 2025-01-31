using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SubjecService
    {
        private SubjectRepository repository;

        public SubjecService(SubjectRepository repository)
        {
            this.repository = repository;
        }

        public void CreateSubject(SubjectCreateDTO subject)
        {
            Subject s = new Subject
            {
                Name = subject.Name,
            };

            this.repository.CreateSubject(s);
        }

        public void UpdateSubject(SubjectUpdateDTO subject, int subjectId)
        {
            Subject s = FindSubject(subjectId);

            if (s == null)
                throw new BadHttpRequestException("Le sujet n'existe pas");

            s.Name = subject.Name;

            this.repository.UpdateSubject(s);
        }

        public Subject FindSubject(int subjectId)
        {
            return this.repository._context.Subjects.Find(subjectId);
        }

        public List<Subject> GetSubjects()
        {
            return this.repository.GetSubjects();
        }
    }
}
