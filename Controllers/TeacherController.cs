using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("teachers")]

    public class TeacherController : Controller
    {
        public readonly TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public ActionResult<ICollection<Teacher>> GetTeachers()
        {
            return Ok(_teacherService.GetTeachers());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateTeacher(TeacherCreateDTO teacher)
        {
            _teacherService.CreateTeacher(teacher);
            return Ok();
        }



        [HttpPut]
        [Route("update/{teacherId}")]
        public ActionResult UpdateTeacher(TeacherUpdateDTO teacher, [FromRoute] int teacherId)
        {
            _teacherService.UpdateTeacher(teacher, teacherId);
            return Ok();
        }
    }
}
