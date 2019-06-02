using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository;
using DataRepository.Extensions;
using Services;
using Services.People;
using SocialCareProject.Areas.Customer.Models.Home;
using SocialCareProject.Areas.Customer.Models.Product;
using SocialCareProject.Authentication;
using SocialCareProject.Models;

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

        [ChildActionOnly]
        public ActionResult NotificationsCount()
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);
            if (currentUser != null && id != default(int))
            {
                var notifs = _customerService.GetNotifications(id).Where(x => !x.IsOpened).ToList();
                ViewBag.Notifications = notifs;
                var a = new NotificationCountModel
                {
                    Number = notifs.Count,
                };

                return PartialView("_Notifications", a);

            }
            else
            {
                var a = new NotificationCountModel
                {
                    Number = 0
                };
                ViewBag.NotificationsAmount = null;
                return PartialView("_Notifications", a);
            }

        }

        public ActionResult Notifications(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var notifications = _customerService.GetPagedNotifications(id);


            var model = new NotificationListModel
            {
                Notifications = notifications.Select(x => new NotificationVewModel
                {
                    IsPositive = x.IsPositive,
                    Text = x.Text,
                    IsOpened = x.IsOpened,
                    CreatedOnUtc = x.CreatedOnUtc.ToString(Constants.DateFormat.ShortDateString),

                }).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(notifications)
            };

         
            foreach (var item in notifications)
            {
                var updateItem = _customerService.GetNotificationById(item.Id);
                updateItem.IsOpened = true;
                _customerService.UpdateNotification(updateItem);
            }
            return View(model);
        }

        public JsonResult GetNotifications(SimplePagerModel pager)
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var notifications = _customerService.GetPagedNotifications(id);


            var model = new NotificationListModel
            {
                Notifications = notifications.Select(x => new NotificationVewModel
                {
                    IsPositive = x.IsPositive,
                    Text = x.Text
                }).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(notifications)
            };

            foreach (var item in notifications)
            {
                var updateItem = _customerService.GetNotificationById(item.Id);
                updateItem.IsOpened = true;
                _customerService.UpdateNotification(updateItem);
            }
            return CreateJsonResult(true, data:model);
        }

    }

}