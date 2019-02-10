using DataRepository.Enums;
using Services;
using Services.Offer;
using Services.People;
using SocialCareProject.Models;
using System.Web.Mvc;

namespace SocialCareProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOfferService _offerService;
        private readonly IAuthenticationService _authenticationService;


        public HomeController(IUserService userService,
            IOfferService offerService,
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _offerService = offerService;
            _authenticationService = authenticationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var validationResult = _authenticationService.ValidateUser(model.Username, model.Password);
            if (validationResult == UserValidationsStatuses.CustomerNotExist)
            {
                ModelState.AddModelError("", "Такого користувача немає в системі");
            }
            else if (validationResult == UserValidationsStatuses.WrongPassword)
            {
                ModelState.AddModelError(nameof(model.Password), "Неправильно введений пароль");
            }
            else if (validationResult == UserValidationsStatuses.NotActive)
            {
                ModelState.AddModelError("", "Користувач є неактивним");
            }
            else if (validationResult == UserValidationsStatuses.Deleted)
            {
                ModelState.AddModelError("", "Користувача було видалено");
            }
            else
            {
                var user = _userService.GetUserByEmail(model.Username);

                _authenticationService.SignIn(user, false);

                switch (user.Role.AreaId)
                {
                    case (int)AreaTypes.Customer:
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                    case (int)AreaTypes.Vendor:
                        return RedirectToAction("Index", "Home", new { area = "Provider" });
                    case (int)AreaTypes.Administration:
                        return RedirectToAction("Index", "Home", new { area = "Worker" });
                }
            }


            return View("Index", model);
        }

        //public ActionResult Logout()
        //{
        //    //external authentication
        //    ExternalAuthorizerHelper.RemoveParameters();

        //    if (_workContext.OriginalCustomerIfImpersonated != null)
        //    {
        //        var isAdmin = _workContext.OriginalCustomerIfImpersonated.IsAdmin();
        //        //logout impersonated customer
        //        _genericAttributeService.SaveAttribute<int?>(_workContext.OriginalCustomerIfImpersonated,
        //            SystemCustomerAttributeNames.ImpersonatedCustomerId, null);

        //        //redirect back to customer details page (admin area)
        //        if (isAdmin)
        //        {
        //            return RedirectToAction("Edit", "Customer",
        //                new { id = _workContext.CurrentCustomer.Id, area = "Admin" });
        //        }
        //        return RedirectToRoute("HomePage");
        //    }



        //    //standard logout 

        //    //activity log
        //    _customerActivityService.InsertActivity("PublicStore.Logout",
        //        _localizationService.GetResource("ActivityLog.PublicStore.Logout"));

        //    _authenticationService.SignOut();
        //    return RedirectToRoute("HomePage");
        //}







        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}