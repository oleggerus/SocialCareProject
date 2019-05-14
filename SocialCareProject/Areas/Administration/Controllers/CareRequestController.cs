using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository.Enums;
using DataRepository.Extensions;
using Services.Assignments;
using Services.People;
using SocialCareProject.Areas.Administration.Models;
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
        private readonly IWorkerPersonAssignmentService _assignmentService;


        public CareRequestController(ICustomerModelFactory customerModelFactory,
            ICustomerService customerService,
            IUserService userService,
            IWorkerPersonAssignmentService assignmentService)
        {
            _customerService = customerService;
            _customerModelFactory = customerModelFactory;
            _userService = userService;
            _assignmentService = assignmentService;
        }

        // GET: Administration/CareRequest
        public ActionResult Index(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);

            var requests = _customerService.GetFilteredCareRequests(currentAdministrationId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PrepareCareRequestsListModel(requests);

            var workers = _assignmentService.GetAllowedForAssignWorkers(currentAdministrationId);
            model.Workers = workers.Select(x => new WorkerForAssignViewModel
            {
                Id = x.Id,
                FullName = x.User.GetFullName()
            }).ToList();

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

        public JsonResult AssignWorkerToCustomer(int customerId, int requestId, string answer)
        {
            var careRequest = _customerService.GetCareRequestById(requestId);

            var currentUser = HttpContext.User as CustomUser;
            careRequest.ReviewedById = _customerService.GetWorkerByUserId(currentUser.UserId).Id;
            careRequest.ReviewedOn = DateTime.UtcNow;
            careRequest.Answer = answer;
            careRequest.StatusId = (int)CareRequestStatuses.Approved;

            _customerService.UpdateCareRequest(careRequest);

            return CreateJsonResult(true);
        }

        public JsonResult RejectCareRequest(int requestId, string answer)
        {
            var careRequest = _customerService.GetCareRequestById(requestId);

            var currentUser = HttpContext.User as CustomUser;
            careRequest.ReviewedById = _customerService.GetWorkerByUserId(currentUser.UserId).Id;
            careRequest.ReviewedOn = DateTime.UtcNow;
            careRequest.Answer = answer;
            careRequest.StatusId = (int) CareRequestStatuses.Rejected;

            _customerService.UpdateCareRequest(careRequest);
            return Json(new { success = true, message = "Ваші зміни збережені" }, JsonRequestBehavior.AllowGet);            
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