using SlamBackend.DTO;
using SlamBackend.Models;
using SlamBackend.Repositories;

namespace SlamBackend.Services
{
    public class OfferService
    {
        private OfferRepository repository;

        public OfferService(OfferRepository repository)
        {
            this.repository = repository;
        }

        public void CreateOffer(OfferCreateDTO offer)
        {
            repository.Create(new Offer
            {
                Name = offer.Name,
                Description = offer.Description,
                Price = offer.Price,
                Duration = offer.Duration,
                BusinessId = offer.BusinessId,
            });
        }

        public Offer FindOffer(int offer_id)
        {
            return repository.getContext().Offers.Find(offer_id);
        }

        public List<Offer> GetOffers()
        {
            return repository.GetAll();
        }
    }
}
