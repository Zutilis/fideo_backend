using Microsoft.AspNetCore.Mvc;
using Fideo.DTO;
using Fideo.Models;
using Fideo.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("appointmentstatus")]

    public class AppointmentStatusController : Controller
    {
        public readonly AppointmentStatusService _service;

        public AppointmentStatusController(AppointmentStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<AppointmentStatus>> getAppointmentStatus()
        {
            return Ok(_service.getAppointmentStatus());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateAppointmentStatus(AppointmentStatusCreateDTO appointment_status)
        {
            _service.CreateAppointmentStatus(appointment_status);
            return Ok();
        }
    }
}
