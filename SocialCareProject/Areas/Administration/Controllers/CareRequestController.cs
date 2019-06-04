using DataRepository.Entities;
using DataRepository.Enums;
using DataRepository.Extensions;
using Services.Assignments;
using Services.People;
using SocialCareProject.Areas.Administration.Models;
using SocialCareProject.Authentication;
using SocialCareProject.Extensions;
using SocialCareProject.Factories;
using SocialCareProject.Models;
using System;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult Index(SimplePagerModel pager, CareRequestFilterModel filter)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);
            var a = new DateTime();
            var b = new DateTime();
            if (filter.StartDate != null)
            {
                a = DateTime.Parse(filter.StartDate);
            }

            if (filter.EndDate != null)
            {
                b = DateTime.Parse(filter.EndDate);
            }
          
            var requests = _customerService.GetFilteredCareRequests(currentAdministrationId, filter.Name, a,
                b,
                filter.StatusId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PrepareCareRequestsListModel(requests);

            var workers = _assignmentService.GetAllowedForAssignWorkers(currentAdministrationId);
            ViewBag.Workers = workers.Select(x => new WorkerForAssignViewModel
            {
                Id = x.UserId,
                FullName = x.User.GetFullName()
            }).ToList();

            return View(model);
        }

        public JsonResult GetFilteredRequests(SimplePagerModel pager, CareRequestFilterModel filter)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);
            var a = new DateTime();
            var b = new DateTime();
            // var ticks = DateTime.ParseExact()

            if (filter.StartDate != null && !string.IsNullOrWhiteSpace(filter.StartDate))
            {
                a = DateTime.ParseExact(filter.StartDate, "dd.MM.yyyy", null);
            }

            if (filter.EndDate!= null && !string.IsNullOrWhiteSpace(filter.EndDate))
            {
                b = DateTime.ParseExact(filter.EndDate, "dd.MM.yyyy", null);
            }
            var requests = _customerService.GetFilteredCareRequests(currentAdministrationId, filter.Name, a,
                b, filter.StatusId,
                 pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PrepareCareRequestsListModel(requests);

            var url = GetUrlWithFilters(pager, currentUser.AreaId);
            return CreateJsonResult(true, url, model);
        }

        public ActionResult AssignWorkerToCustomer(int requestId, string answer, int? workerId = null)
        {
            var errorMessage = string.Empty;
            if (!workerId.HasValue)
            {
                errorMessage = "Оберіть соціального робітника";
                return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);

            }
            if (string.IsNullOrWhiteSpace(answer))
            {
                errorMessage = "Додайте коментар";
                return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);

            }

            if (!ModelState.IsValid)
            {
                return new ModelStateJsonResult(ModelState);
            }

            var careRequest = _customerService.GetCareRequestById(requestId);

            var currentUser = HttpContext.User as CustomUser;
            var currentWorker = _customerService.GetWorkerByUserId(currentUser.UserId);
            var assignedWorker = _customerService.GetWorkerByUserId(workerId.Value);
            careRequest.ReviewedById = currentWorker.Id;
            careRequest.ReviewedOn = DateTime.UtcNow;
            careRequest.Answer = answer;
            careRequest.StatusId = (int)CareRequestStatuses.Approved;
            _customerService.UpdateCareRequest(careRequest);

            var person = _customerService.GetCustomerById(careRequest.CustomerId);
            person.StatusId = (int)CustomerCareStatuses.ПідДоглядом;

            var assignment = new WorkerPersonAssignment
            {
                CustomerId = person.Id,
                AssignmentStatusId = (int)WorkerPersonAssignmentStatuses.Активно,
                CreatedOnUtc = DateTime.UtcNow,
                WorkerId = assignedWorker.Id,
                ReviewedByUserId = currentUser.UserId,

            };
            _customerService.InsertAssignment(assignment);
            _customerService.Update(person);

            var custUser = _customerService.GetCustomerById(careRequest.CustomerId);
            var notification = new Notification
            {
                IsOpened = false,
                IsPositive = true,
                Text = answer,
                CreatedOnUtc = DateTime.UtcNow,
                UserId = custUser.UserId
            };
            _customerService.InsertNotification(notification);

            return Json(new { success = true, message = "Ваші зміни збережені" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RejectCareRequest(int requestId, string answer)
        {
            var errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(answer))
            {
                errorMessage = "Додайте коментар";
                return Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);

            }
            var careRequest = _customerService.GetCareRequestById(requestId);

            var currentUser = HttpContext.User as CustomUser;
            careRequest.ReviewedById = _customerService.GetWorkerByUserId(currentUser.UserId).Id;
            careRequest.ReviewedOn = DateTime.UtcNow;
            careRequest.Answer = answer;
            careRequest.StatusId = (int)CareRequestStatuses.Rejected;

            _customerService.UpdateCareRequest(careRequest);

            var custUser = _customerService.GetCustomerById(careRequest.CustomerId);
            var notification = new Notification
            {
                IsOpened = false,
                IsPositive = false,
                CreatedOnUtc = DateTime.UtcNow,
                Text = answer,
                UserId = custUser.UserId
            };
            _customerService.InsertNotification(notification);

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