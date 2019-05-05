using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.People;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Administration.Controllers
{
    public class CareRequestController : BaseAdministrationController
    {
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;


        public CareRequestController(ICustomerModelFactory customerModelFactory,
            ICustomerService customerService,
            IUserService userService)
        {
            _customerService = customerService;
            _customerModelFactory = customerModelFactory;
            _userService = userService;
        }

        // GET: Administration/CareRequest
        public ActionResult Index(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);

            var requests = _customerService.GetFilteredCareRequests(currentAdministrationId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PrepareCareRequestsListModel(requests);

            return View(model);
        }

        public JsonResult GetFilteredRequests(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);

            var requests = _customerService.GetFilteredCareRequests(currentAdministrationId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PrepareCareRequestsListModel(requests);

            var url = GetUrlWithFilters(pager, currentUser.AreaId);
            return CreateJsonResult(true, url, model);
        }

        private string GetUrlWithFilters(SimplePagerModel pager, int administrationId)
        {
            var urlParams = new
            {
                administrationId,
                pageIndex = pager.PageIndex,
                pageSize = pager.PageSize
            };

            return Url.Action("Index", urlParams);
        }
    }
}