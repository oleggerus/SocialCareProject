using System;
using System.Linq;
using DataRepository;
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

        public IPagedList<DataRepository.Entities.Orders.Offer> GetFilteredOffers(int pageIndex = default(int), int pageSize = Int32.MaxValue)
        {
            var query = _offerRepository.TableNoTracking.Where(x => !x.IsDeleted);

            return new PagedList<DataRepository.Entities.Orders.Offer>(query.OrderBy(x => x.CreatedOnUtc), pageIndex,
                pageSize);
        }
    }
}
