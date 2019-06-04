using Services.People;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;
using System.Web.Mvc;

namespace SocialCareProject.Areas.Administration.Controllers
{
    public class WorkerController : BaseAdministrationController
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly IUserService _userService;

        public WorkerController(ICustomerService customerService,
            ICustomerModelFactory customerModelFactory,
            IUserService userService)
        {
            _customerService = customerService;
            _customerModelFactory = customerModelFactory;
            _userService = userService;
        }

        // GET: Administration/Worker
        public ActionResult Index(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);

            var workers = _customerService.GetFilteredWorkers(currentAdministrationId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PrepareWorkersListViewModel(workers);

            return View(model);
        }

        public JsonResult GetFilteredSocialWorkers(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);

            var workers = _customerService.GetFilteredWorkers(currentAdministrationId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PrepareWorkersListViewModel(workers);

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