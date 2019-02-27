using DataRepository;
using DataRepository.Entities.Orders;
using DataRepository.RepositoryPattern;
using System;
using System.Linq;

namespace Services.Offer
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<DataRepository.Entities.Orders.Offer> _offerRepository;
        private readonly IRepository<PersonRequest> _personRequestService;


        public OfferService(IRepository<DataRepository.Entities.Orders.Offer> offerRepository,
            IRepository<PersonRequest> personRequestService)
        {
            _offerRepository = offerRepository;
            _personRequestService = personRequestService;
        }

        public IQueryable<DataRepository.Entities.Orders.Offer> GetAllOffers()
        {
            return _offerRepository.TableNoTracking;
        }

        public IPagedList<DataRepository.Entities.Orders.Offer> GetFilteredOffers(int customerId, int pageIndex = default(int), int pageSize = Int32.MaxValue)
        {
            var query = _offerRepository.TableNoTracking.Where(x => !x.IsDeleted && x.Customer.User.Id == customerId);

            return new PagedList<DataRepository.Entities.Orders.Offer>(query.OrderBy(x => x.CreatedOnUtc), pageIndex,
                pageSize);
        }

        public IPagedList<PersonRequest> GetFilteredPersonRequests(int customerId, int pageIndex = default(int), int pageSize = Int32.MaxValue)
        {
            var query = _personRequestService.TableNoTracking.Where(x => !x.IsDeleted && x.Customer.UserId == customerId);
            var a = _personRequestService.TableNoTracking.Where(x => !x.IsDeleted)
                .ToList();
            return new PagedList<PersonRequest>(query.OrderBy(x => x.CreatedOnUtc), pageIndex, pageSize);
        }
    }
}
