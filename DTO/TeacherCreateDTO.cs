using System.ComponentModel.DataAnnotations;

namespace SlamBackend.DTO
{
    public class TeacherCreateDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
