using Microsoft.AspNetCore.Authorization;
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
        public readonly OfferService _offerService;

        public BusinessController(BusinessService service,
            OfferService offerService)
        {
            _service = service;
            _offerService = offerService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("me")]
        public async Task<IActionResult> GetBusinessByUser()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return Ok(_service.GetBusinessByUser(userId));
        }

        [HttpPost("create")]
        public ActionResult CreateBusiness(BusinessCreateDTO business)
        {
            _service.CreateBusiness(business);
            return Ok(business);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBusiness(int id)
        {
            return Ok(_service.GetBusiness(id));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("{id:int}/offers/create")]
        public ActionResult CreateOffer(int id, [FromBody] OfferCreateDTO offer)
        {
            var userId = User.FindFirst("Id")?.Value;

            var business = _service.GetBusiness(id);
            if (business == null)
                return NotFound("Business non trouvé");

            if (business.OwnerId != userId)
                return StatusCode(403, "Vous n'êtes pas autorisé à créer une offre pour ce commerce.");

            _offerService.CreateOffer(id, offer);
            return Ok();
        }

        [HttpGet("{id:int}/offers")]
        public ActionResult<List<Offer>> GetOffersByBusiness(int id)
        {
            return Ok(_offerService.GetOffersByBusiness(id));
        }
    }
}
