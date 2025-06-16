using Fideo.DTO;
using Fideo.Models;
using Fideo.Repositories;

namespace Fideo.Services
{
    public class OfferService
    {
        private OfferRepository repository;

        public OfferService(OfferRepository repository)
        {
            this.repository = repository;
        }

        public void CreateOffer(int businessId, OfferCreateDTO offer)
        {
            repository.Create(new Offer
            {
                Name = offer.Name,
                Description = offer.Description,
                Price = offer.Price,
                Duration = offer.Duration,
                BusinessId = businessId,
            });
        }

        public List<Offer> GetOffersByBusiness(int businessId)
        {
            return repository.getContext().Offers
                .Where(o => o.BusinessId == businessId)
                .ToList();
        }

        public List<Offer> GetOffers()
        {
            return repository.GetAll();
        }
    }
}
