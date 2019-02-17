using System.Linq;
using DataRepository;

namespace Services.Offer
{
    public interface IOfferService
    {
        IQueryable<DataRepository.Entities.Orders.Offer> GetAllOffers();

        IPagedList<DataRepository.Entities.Orders.Offer> GetFilteredOffers(int pageIndex = default(int), int pageSize = int.MaxValue);

    }
}
