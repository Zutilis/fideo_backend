using Microsoft.AspNetCore.Mvc;
using Fideo.DTO;
using Fideo.Models;
using Fideo.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("businesses")]

    public class BusinessController : Controller
    {
        public readonly BusinessService _service;

        public BusinessController(BusinessService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<Business>> GetBusinesses()
        {
            return Ok(_service.getBusinesses());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateBusiness(BusinessCreateDTO business)
        {
            _service.CreateBusiness(business);
            return Ok();
        }
    }
}
