using System.Linq;
namespace Services.Offer
{
    public interface IOfferService
    {
        IQueryable<DataRepository.Entities.Orders.Offer> GetAllOffers();
    }
}
