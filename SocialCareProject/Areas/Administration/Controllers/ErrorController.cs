using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCareProject.Areas.Administration.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Provider/Errror
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}