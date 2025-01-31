using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("subjects")]

    public class SubjectController : Controller
    {
        public readonly SubjecService _subjectService;

        public SubjectController(SubjecService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public ActionResult<ICollection<Subject>> GetSubjects()
        {
            return Ok(_subjectService.GetSubjects());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateSubject(SubjectCreateDTO subject)
        {
            _subjectService.CreateSubject(subject);
            return Ok();
        }

        [HttpPut]
        [Route("update/{subjectId}")]
        public ActionResult UpdateSubject(SubjectUpdateDTO subject, [FromRoute] int subjectId)
        {
            _subjectService.UpdateSubject(subject, subjectId);
            return Ok();
        }
    }
}
