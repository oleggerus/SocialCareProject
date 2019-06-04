using DataRepository;
using DataRepository.Entities.Orders;
using DataRepository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Offer
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<DataRepository.Entities.Orders.Offer> _offerRepository;
        private readonly IRepository<PersonRequest> _personRequestrRepository;
        private readonly IRepository<Category> _categoryRepository;



        public OfferService(IRepository<DataRepository.Entities.Orders.Offer> offerRepository,
            IRepository<PersonRequest> personRequestService, IRepository<Category> categoryRepository)
        {
            _offerRepository = offerRepository;
            _personRequestrRepository = personRequestService;
            _categoryRepository = categoryRepository;
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
            var query = _personRequestrRepository.TableNoTracking.Where(x => !x.IsDeleted && x.Customer.UserId == customerId);

            return new PagedList<PersonRequest>(query.OrderBy(x => x.CreatedOnUtc), pageIndex, pageSize);
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public IList<KeyValuePair<int, string>> GetCategories()
        {
            return _categoryRepository.TableNoTracking.ToList().Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();
        }

        public PersonRequest InsertPersonRequest(PersonRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _personRequestrRepository.Insert(request);

            return request;
        }
    }
}
