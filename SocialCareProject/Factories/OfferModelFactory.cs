using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository;
using DataRepository.Entities.Orders;
using DataRepository.Enums;
using DataRepository.Extensions;
using SocialCareProject.Areas.Customer.Models.Offer;

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
    }
}