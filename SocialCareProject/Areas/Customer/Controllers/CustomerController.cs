using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository.Entities.People;
using DataRepository.Enums;
using Services.People;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class CustomerController : BaseCustomerController
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
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var customer = _customerService.GetCustomerByUserId(currentUser.UserId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var ad = customer.Administration;
            var contact = ad.Contact;
            var customerModel = _customerModelFactory.PrepareCustomerModel(customer);

            ViewBag.CanCreateCareRequest = _customerService.CanCreateCareRequest(customer.Id);

            return View("CustomerDetails", customerModel);
        }

        public JsonResult MakeCareRequest(int customerId, string reason)
        {
            var customer = _customerService.GetCustomerById(customerId);

            if (string.IsNullOrWhiteSpace(reason))
            {
                return Json(new { success = false, message = "Додайте необхідну інформацію" }, JsonRequestBehavior.AllowGet);
            }

            if (!_customerService.CanCreateCareRequest(customer.Id))
            {
                return Json(new { success = false, message = "Такий запит уже існує в системі" }, JsonRequestBehavior.AllowGet);
            }
            var careRequest = new CareRequest
            {
                CustomerId = customerId,
                Reason = reason,
                StatusId = (int)CareRequestStatuses.Opened
            };

            
            _customerService.InsertCareRequest(careRequest);
            return Json(new { success = true, message = "Ваш запит був успішно створений" }, JsonRequestBehavior.AllowGet);
        }
    }

}