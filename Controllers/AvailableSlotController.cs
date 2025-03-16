using Microsoft.AspNetCore.Mvc;
using Fideo.DTO;
using Fideo.Models;
using Fideo.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("availableslots")]

    public class AvailableSlotController : Controller
    {
        public readonly AvailableSlotService _service;

        public AvailableSlotController(AvailableSlotService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<AvailableSlot>> GetAvailableSlots()
        {
            return Ok(_service.GetAvailableSlots());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateAvailableSlot(AvailabelSlotCreateDTO available_slot)
        {
            _service.CreateAvailableSlot(available_slot);
            return Ok();
        }
    }
}
