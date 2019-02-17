using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.People;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerModelFactory customerModelFactory,
            ICustomerService customerService)
        {
            _customerService = customerService;
            _customerModelFactory = customerModelFactory;
        }


        // GET: Customer/Customer
        public ActionResult Index()
        {
            if (!(HttpContext.User is CustomUser currentUser))
            {
                return  RedirectToAction("Index", "Home", new { area = "" });
            }

            var customer = _customerService.GetCustomerByUserId(currentUser.UserId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var customerModel = _customerModelFactory.PrepareCustomerModel(customer);

            return View("CustomerDetails", customerModel);

        }
    }
}