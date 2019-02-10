using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Services.Offer;
using Services.People;

namespace SocialCareProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOfferService _offerService;


        public HomeController(IUserService userService,
            IOfferService offerService)
        {
            _userService = userService;
            _offerService = offerService;
        }

        public ActionResult Index()
        {
            _offerService.GetAllOffers();
            _userService.GetAllUsers();
            return View();
        }

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