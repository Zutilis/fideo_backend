using Fideo.DTO;
using Fideo.Models;
using Fideo.Repositories;

namespace Fideo.Services
{
    public class BusinessService
    {
        private BusinessRepository repository;

        public BusinessService(BusinessRepository repository)
        {
            this.repository = repository;
        }

        public void CreateBusiness(BusinessCreateDTO business)
        {
            repository.Create(new Business
            {
                Name = business.Name,
                Description = business.Description,
                Street = business.Street,
                City = business.City,
                PostalCode = business.PostalCode,
                Country = business.Country,
                PhoneNumber = business.PhoneNumber,
                PointsPerEuro = business.PointsPerEuro,
                CreatedAt = business.CreatedAt,
                OwnerId = business.OwnerId,
            });
        }

        public Business GetBusiness(int business_id)
        {
            return repository.getContext()
                .Businesses
                .Find(business_id);
        }

        public List<Business> GetBusinessByUser(string user_id)
        {
            return repository.getContext()
                .Businesses
                .Where(b => b.OwnerId == user_id)
                .ToList();
        }

        public List<Business> GetBusinesses()
        {
            return repository.GetAll();
        }
    }
}
