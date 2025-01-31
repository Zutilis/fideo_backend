using SlamBackend.DTO;
using SlamBackend.Models;
using SlamBackend.Repositories;

namespace SlamBackend.Services
{
    public class CourseService
    {
        private CourseRepository repository;

        public CourseService(CourseRepository repository)
        {
            this.repository = repository;
        }

        public void CreateCourse(CourseCreateDTO course)
        {
            Business c = new Business
            {
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                IdTeacher = course.IdTeacher,
                IdSubject = course.IdSubject,
            };

            this.repository.CreateCourse(c);
        }

        public void UpdateCourse(CourseUpdateDTO course, int subjectId)
        {
            Business c = FindSubject(subjectId);

            if (c == null)
                throw new BadHttpRequestException("Le sujet n'existe pas");

            c.StartDate = course.StartDate;
            c.EndDate = course.EndDate;
            c.IdTeacher = course.IdTeacher;
            c.IdSubject = course.IdSubject;

            this.repository.UpdateCourse(c);
        }

        public Business FindSubject(int courseId)
        {
            return this.repository._context.Courses.Find(courseId);
        }

        public List<Business> GetCourses()
        {
            return this.repository.GetCourses();
        }
    }
}
