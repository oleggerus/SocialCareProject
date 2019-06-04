using System.Web.Mvc;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Customer/Error
        public ActionResult AccessDenied()
        {
            return View();
        }

    }
}