using System.Linq;
using DataRepository.RepositoryPattern;

namespace Services.Offer
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<DataRepository.Entities.Orders.Offer> _offerRepository;

        public OfferService(IRepository<DataRepository.Entities.Orders.Offer> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IQueryable<DataRepository.Entities.Orders.Offer> GetAllOffers()
        {
            return _offerRepository.TableNoTracking;
        }

    }
}
