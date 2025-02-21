using Microsoft.AspNetCore.Mvc;
using SlamBackend.DTO;
using SlamBackend.Models;
using SlamBackend.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("offers")]

    public class OfferController : Controller
    {
        public readonly OfferService _service;

        public OfferController(OfferService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<Offer>> GetOffers()
        {
            return Ok(_service.GetOffers());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateOffer(OfferCreateDTO offer)
        {
            _service.CreateOffer(offer);
            return Ok();
        }
    }
}
