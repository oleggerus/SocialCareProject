using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository.Extensions;
using Services;
using Services.People;
using SocialCareProject.Areas.Customer.Models.Administration;
using SocialCareProject.Authentication;

namespace SocialCareProject.Areas.Administration.Controllers
{
    public class HomeController : BaseAdministrationController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerService _customerService;

        public HomeController(
            IAuthenticationService authenticationService,
            ICustomerService customerService)
        {
            _customerService = customerService;
            _authenticationService = authenticationService;
        }
        // GET: Customer/Home
        public ActionResult Index()
        {
            var usr = _authenticationService.GetAuthenticatedCustomer();
            var a = System.Web.HttpContext.Current.User;

            return View();
        }

        public ActionResult Administration()
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var customer = _customerService.GetWorkerByUserId(id);
            var address = new AdministrationViewModel
            {
                Administration = customer.Administration.Name,
                AdministrationContactName = customer.Administration.Contact.GetFullName(),
                AdministrationPhone = customer.Administration.Phone,
                Description = customer.Administration.Url,
                Email = customer.Administration.Email,
                Address = customer.Administration.Address.City + ", " + customer.Administration.Address.Street + ", " +
                          customer.Administration.Address.HouseNameRoomNumber + " "

            };
            return View(address);
        }

    }

}