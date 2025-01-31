using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
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
            Course c = new Course
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
            Course c = FindSubject(subjectId);

            if (c == null)
                throw new BadHttpRequestException("Le sujet n'existe pas");

            c.StartDate = course.StartDate;
            c.EndDate = course.EndDate;
            c.IdTeacher = course.IdTeacher;
            c.IdSubject = course.IdSubject;

            this.repository.UpdateCourse(c);
        }

        public Course FindSubject(int courseId)
        {
            return this.repository._context.Courses.Find(courseId);
        }

        public List<Course> GetCourses()
        {
            return this.repository.GetCourses();
        }
    }
}
