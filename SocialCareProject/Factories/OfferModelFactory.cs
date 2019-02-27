using DataRepository;
using DataRepository.Entities.Orders;
using DataRepository.Enums;
using DataRepository.Extensions;
using SocialCareProject.Areas.Customer.Models.Offer;
using System;
using System.Linq;

namespace SocialCareProject.Factories
{
    public class OfferModelFactory : IOfferModelFactory
    {
        public OfferItemModel PrepareOfferItemModel(Offer offer)
        {
            return new OfferItemModel
            {
                Id = offer.Id,
                Category = offer.Product.Category.Name,
                Name = offer.Product.Name,
                ModifiedOnUtc = offer.StatusId == (int)OfferStatuses.PendingReview ? offer.CreatedOnUtc.ToString(Constants.DateFormat.ShortDateString) :
                   (offer.ReviewedOnUtc.HasValue ? offer.ReviewedOnUtc.Value.ToString(Constants.DateFormat.ShortDateString) : offer.CreatedOnUtc.ToString(Constants.DateFormat.ShortDateString)),
                Manufacturer = offer.Product.Manufacturer,
                Price = offer.Product.Price,
                Picture = offer.Product.Picture,
                Description = offer.Description,
                Status = ((OfferStatuses)offer.StatusId).Description(),
                StatusId = offer.StatusId
            };
        }

        public OfferModel PrepareOfferModel(Offer offer)
        {
            throw new NotImplementedException();
        }

        public OfferListModel PrepareProductListModel(IPagedList<Offer> offers)
        {
            return new OfferListModel()
            {
                Offers = offers.Select(PrepareOfferItemModel).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(offers)
            };
        }

        public PersonRequestItemModel PreparePersonRequestItemModel(PersonRequest request)
        {
            return new PersonRequestItemModel
            {
                CreatedOnUtc = request.CreatedOnUtc.ToString(Constants.DateFormat.ShortDateString),
                ClosedOnUtc = request.StatusId == (int)PersonRequestStatuses.Closed? new DateTime(2019, 02, 01).ToString(Constants.DateFormat.ShortDateString) : new DateTime().ToString(Constants.DateFormat.ShortDateString), 
                Description = request.Description,
                Category = request.Category.Name,
                Id =  request.Id,
                StatusId = request.StatusId,
                Name = request.Name,
                Status = ((PersonRequestStatuses)request.StatusId).Description(),
            };
        }

        public PersonRequestListModel PreparePersonRequestsListModel(IPagedList<PersonRequest> requests)
        {
            return new PersonRequestListModel
            {
                Items = requests.Select(PreparePersonRequestItemModel).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(requests)
            };
        }
    }
}