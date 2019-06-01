using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository.Extensions;
using Services;
using Services.People;
using SocialCareProject.Areas.Customer.Models.Home;
using SocialCareProject.Authentication;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class HomeController : BaseCustomerController
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
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var customer = _customerService.GetCustomerByUserId(currentUser.UserId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var model = new HomeCustomerModel
            {
                Id = id,
                Name = customer.User.GetFullName()
            };

            return View(model);
        }
       
    }
}