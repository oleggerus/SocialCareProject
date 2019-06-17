using DataRepository.Entities.Orders;
using DataRepository.Enums;
using Services.Offer;
using Services.People;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;
using System;
using System.Web.Mvc;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class OfferController : BaseCustomerController
    {
        private readonly IOfferService _offerService;
        private readonly IOfferModelFactory _offerModelFactory;
        private readonly ICustomerService _customerService;

        public OfferController(IOfferService offerService,
            IOfferModelFactory offerModelFactory,
            ICustomerService customerService)
        {
            _offerService = offerService;
            _offerModelFactory = offerModelFactory;
            _customerService = customerService;
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

            ViewBag.Categories = _offerService.GetCategories();
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

        public JsonResult CreateNewRequest(string name, string description, int? categoryId = null)
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);
            if (string.IsNullOrWhiteSpace(name))
            {
                return Json(new { success = false, message = "Заповніть поле вводу для назви" }, JsonRequestBehavior.AllowGet);
            }
            if ( string.IsNullOrWhiteSpace(description) )
            {
                return Json(new { success = false, message = "Заповніть поле вводу для детального опису" }, JsonRequestBehavior.AllowGet);
            }
            if (!categoryId.HasValue)
            {
                return Json(new { success = false, message = "Оберіть категорію, до якої належати дане побажання" }, JsonRequestBehavior.AllowGet);
            }

            var customer = _customerService.GetCustomerByUserId(id);
            var cat = _offerService.GetCategoryById(categoryId.Value);
            if (cat == null)
            {
                return Json(new { success = false, message = "Обрано некоректну категорію" }, JsonRequestBehavior.AllowGet);

            }

            var request = new PersonRequest
            {
                StatusId = (int)PersonRequestStatuses.Opened,
                Name = name,
                Description = description,
                IsDeleted = false,
                CustomerId = customer.Id,
                CategoryId = categoryId.Value,
                CreatedById = customer.Id,
                CreatedOnUtc = DateTime.UtcNow
            };
            _offerService.InsertPersonRequest(request);

            return Json(new { success = true, message = "Ваше побажання було збережено" }, JsonRequestBehavior.AllowGet);
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