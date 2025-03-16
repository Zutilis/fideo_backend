using Microsoft.AspNetCore.Mvc;
using Fideo.DTO;
using Fideo.Models;
using Fideo.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("appointments")]

    public class AppointmentController : Controller
    {
        public readonly AppointmentService _service;

        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<Appointment>> GetAppointments()
        {
            return Ok(_service.getAppointments());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateAppointment(AppointmentCreateDTO appointment)
        {
            _service.CreateAppointment(appointment);
            return Ok();
        }
    }
}
