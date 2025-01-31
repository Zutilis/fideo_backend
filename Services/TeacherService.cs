
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class TeacherService
    {
        private TeacherRepository repository;

        public TeacherService(TeacherRepository repository)
        {
            this.repository = repository;
        }

        public void CreateTeacher(TeacherCreateDTO teacher)
        {
            Teacher t = new Teacher
            {
                BirthDate = teacher.BirthDate,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
            };

            this.repository.CreateTeacher(t);
        }

        public void UpdateTeacher(TeacherUpdateDTO teacher, int teacherId)
        {
            Teacher t = FindTeacher(teacherId);

            if (t == null)
                throw new BadHttpRequestException("Le professeur n'existe pas");

            t.BirthDate = teacher.BirthDate;
            t.FirstName = teacher.FirstName;
            t.LastName = teacher.LastName;

            this.repository.UpdateTeacher(t);
        }

        public Teacher FindTeacher(int teacherId)
        {
            return this.repository._context.Teachers.Find(teacherId);
        }

        public List<Teacher> GetTeachers()
        {
            return this.repository.GetTeachers();
        }
    }
}
