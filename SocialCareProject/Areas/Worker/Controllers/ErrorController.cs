using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCareProject.Areas.Worker.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Worker/Error
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}