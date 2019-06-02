using System.Collections.Generic;
using System.Linq;
using DataRepository;
using DataRepository.Entities.Orders;

namespace Services.Offer
{
    public interface IOfferService
    {
        IQueryable<DataRepository.Entities.Orders.Offer> GetAllOffers();

        IPagedList<DataRepository.Entities.Orders.Offer> GetFilteredOffers(int customerId, int pageIndex = default(int), int pageSize = int.MaxValue);

        IPagedList<PersonRequest> GetFilteredPersonRequests(int customerId, int pageIndex = default(int), int pageSize = int.MaxValue);

        Category GetCategoryById(int id);
        IList<KeyValuePair<int, string>> GetCategories();
        PersonRequest InsertPersonRequest(PersonRequest request);
    }
}
