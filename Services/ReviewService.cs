using Fideo.DTO;
using Fideo.Models;
using Fideo.Repositories;

namespace Fideo.Services
{
    public class ReviewService
    {
        private ReviewRepository repository;

        public ReviewService(ReviewRepository repository)
        {
            this.repository = repository;
        }

        public void CreateReview(ReviewCreateDTO review)
        {
            repository.Create(new Review
            {
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt,
                AppointmentId = review.AppointmentId,
            });
        }

        public Review GetReview(int review_id)
        {
            return repository.getContext().Reviews.Find(review_id);
        }

        public List<Review> GetReviews()
        {
            return repository.GetAll();
        }
    }
}
