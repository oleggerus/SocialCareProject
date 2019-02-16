using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace SocialCareProject.Areas.Provider.Controllers
{
    public class HomeController : BaseProviderController
    {
        private readonly IAuthenticationService _authenticationService;
        public HomeController(
            IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;
        }
        // GET: Customer/Home
        public ActionResult Index()
        {
            var usr = _authenticationService.GetAuthenticatedCustomer();
            var a = System.Web.HttpContext.Current.User;

            return View();
        }

    }

}