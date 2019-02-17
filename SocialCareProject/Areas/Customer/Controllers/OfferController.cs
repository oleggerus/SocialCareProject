using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Offer;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class OfferController : BaseCustomerController
    {
        private readonly IOfferService _offerService;
        private readonly IOfferModelFactory _offerModelFactory;

        public OfferController(IOfferService offerService,
            IOfferModelFactory offerModelFactory)
        {
            _offerService = offerService;
            _offerModelFactory = offerModelFactory;
        }

        public ActionResult Index(SimplePagerModel pager)
        {
            var offers = _offerService.GetFilteredOffers(pager.PageIndex, pager.PageSize);

            var model = _offerModelFactory.PrepareProductListModel(offers);

            return View(model);
        }

        public JsonResult GetFilteredOffers(SimplePagerModel pager)
        {
            var offers = _offerService.GetFilteredOffers(pager.PageIndex, pager.PageSize);
            var model = _offerModelFactory.PrepareProductListModel(offers);
            var url = GetUrlWithFilters(pager);

            return CreateJsonResult(true, url, model);
        }

        private string GetUrlWithFilters(SimplePagerModel pager)
        {
            var urlParams = new
            {
                pageIndex = pager.PageIndex,
                pageSize = pager.PageSize
            };

            return Url.Action("Index", urlParams);
        }
    }
}