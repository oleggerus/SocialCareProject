using System.Web.Mvc;
using Services.People;
using SocialCareProject.Areas.Administration.Models;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Administration.Controllers
{
    public class PeopleController : BaseAdministrationController
    {

        private readonly ICustomerService _customerService;
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly IUserService _userService;

       public PeopleController(ICustomerService customerService,
           ICustomerModelFactory customerModelFactory,
           IUserService userService)
        {
            _customerService = customerService;
            _customerModelFactory = customerModelFactory;
            _userService = userService;
        }

        // GET: Administration/People
        public ActionResult Index(SimplePagerModel pager, PeopleFilterModel filter)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);

            var people = _customerService.GetFilteredCustomers(currentAdministrationId, filter.Name, filter.Phone,
                filter.Email, filter.StatusId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PreparePeopleListViewModel(people);
            model.Filter = filter;
            
            return View(model);
        }

        public JsonResult GetFilteredPeople(SimplePagerModel pager, PeopleFilterModel filter)
        {
            var currentUser = HttpContext.User as CustomUser;
            var currentAdministrationId = _userService.GetAdministrationIdByUserId(currentUser.UserId);

            var people = _customerService.GetFilteredCustomers(currentAdministrationId, filter.Name, filter.Phone,
                filter.Email, filter.StatusId, pager.PageIndex, pager.PageSize);
            var model = _customerModelFactory.PreparePeopleListViewModel(people);

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