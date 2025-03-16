using Microsoft.AspNetCore.Mvc;
using Fideo.DTO;
using Fideo.Models;
using Fideo.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("reviews")]

    public class ReviewController : Controller
    {
        public readonly ReviewService _service;

        public ReviewController(ReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<Review>> GetReviews()
        {
            return Ok(_service.GetReviews());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateReview(ReviewCreateDTO review)
        {
            _service.CreateReview(review);
            return Ok();
        }
    }
}
