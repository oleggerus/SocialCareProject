﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Customer/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}