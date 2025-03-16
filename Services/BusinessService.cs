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
                DiscountTreshold = business.DiscountTreshold,
                DiscountValue = business.DiscountValue,
                CreatedAt = business.CreatedAt,
                OwnerId = business.OwnerId,
            });
        }

        public Business FindBusiness(int business_id)
        {
            return repository.getContext().Businesses.Find(business_id);
        }

        public List<Business> getBusinesses()
        {
            return repository.GetAll();
        }
    }
}
