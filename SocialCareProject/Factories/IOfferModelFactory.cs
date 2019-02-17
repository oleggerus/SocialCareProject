using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository;
using DataRepository.Entities.Orders;
using SocialCareProject.Areas.Customer.Models.Offer;

namespace SocialCareProject.Factories
{
    public interface IOfferModelFactory
    {
        OfferItemModel PrepareOfferItemModel(Offer offer);

        OfferModel PrepareOfferModel(Offer offer);

        OfferListModel PrepareProductListModel(IPagedList<Offer> offers);
    }
}