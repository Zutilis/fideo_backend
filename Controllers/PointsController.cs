using Microsoft.AspNetCore.Mvc;
using Fideo.DTO;
using Fideo.Models;
using Fideo.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("points")]

    public class PointsController : Controller
    {
        public readonly PointsService _service;

        public PointsController(PointsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<Points>> GetPoints()
        {
            return Ok(_service.getPoints());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreatePoints(PointsCreateDTO points)
        {
            _service.CreatePoints(points);
            return Ok();
        }
    }
}
