using SlamBackend.DTO;
using SlamBackend.Models;
using SlamBackend.Repositories;

namespace SlamBackend.Services
{
    public class PointsService
    {
        private PointsRepository repository;

        public PointsService(PointsRepository repository)
        {
            this.repository = repository;
        }

        public void CreatePoints(PointsCreateDTO points)
        {
            repository.Create(new Points
            {
                UserId = points.UserId,
                BusinessId = points.BusinessId,
                Balance = points.Balance,
                LastUpdatedDate = points.LastUpdatedDate,
            });
        }

        public Points FindPoints(int points_id)
        {
            return repository.getContext().Points.Find(points_id);
        }

        public List<Points> getPoints()
        {
            return repository.GetAll();
        }
    }
}
