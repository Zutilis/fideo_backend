using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("courses")]

    public class CourseController : Controller
    {
        public readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<ICollection<CourseUpdateDTO>> GetCourses()
        {
            return Ok(_courseService.GetCourses());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateCourse(CourseCreateDTO course)
        {
            _courseService.CreateCourse(course);
            return Ok();
        }

        [HttpPut]
        [Route("update/{courseId}")]
        public ActionResult UpdateCourse(CourseUpdateDTO course, [FromRoute] int courseId)
        {
            _courseService.UpdateCourse(course, courseId);
            return Ok();
        }
    }
}
