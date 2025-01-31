using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SlamBackend.Models;

namespace SlamBackend.DTO
{
    public class CourseCreateDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdTeacher { get; set; }
        public int IdSubject { get; set; }
    }
}
