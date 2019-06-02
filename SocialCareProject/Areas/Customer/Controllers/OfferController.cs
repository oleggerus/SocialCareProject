using Services.Offer;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;
using System.Web.Mvc;

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
            var currentUser = HttpContext.User as CustomUser;

            var offers = _offerService.GetFilteredOffers(currentUser?.UserId ?? default(int), pager.PageIndex, pager.PageSize);

            var model = _offerModelFactory.PrepareProductListModel(offers);

            return View(model);
        }

        public JsonResult GetFilteredOffers(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var offers = _offerService.GetFilteredOffers(id, pager.PageIndex, pager.PageSize);
            var model = _offerModelFactory.PrepareProductListModel(offers);
            var url = GetUrlWithFilters(pager, id);

            return CreateJsonResult(true, url, model);
        }

        public ActionResult PersonRequestList(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;

            var personRequests = _offerService.GetFilteredPersonRequests(currentUser?.UserId ?? default(int), pager.PageIndex, pager.PageSize);
            var model = _offerModelFactory.PreparePersonRequestsListModel(personRequests);

            if (currentUser != null) ViewBag.UserId = currentUser.UserId;
            return View("PersonRequestList", model);
        }

        public JsonResult GetFilteredPersonRequests(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);
            var personRequests = _offerService.GetFilteredPersonRequests(id, pager.PageIndex, pager.PageSize);
            var model = _offerModelFactory.PreparePersonRequestsListModel(personRequests);
            var url = GetUrlWithFiltersForRequests(pager, id);

            return CreateJsonResult(true, url, model);
        }

        private string GetUrlWithFilters(SimplePagerModel pager, int customerId)
        {
            var urlParams = new
            {
                customerId,
                pageIndex = pager.PageIndex,
                pageSize = pager.PageSize
            };

            return Url.Action("Index", urlParams);
        }

        private string GetUrlWithFiltersForRequests(SimplePagerModel pager, int customerId)
        {
            var urlParams = new
            {
                customerId,
                pageIndex = pager.PageIndex,
                pageSize = pager.PageSize
            };

            return Url.Action("PersonRequestList", urlParams);
        }

    }
}