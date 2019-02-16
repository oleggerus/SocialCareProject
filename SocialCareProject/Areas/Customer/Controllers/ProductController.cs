using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class ProductController : BaseCustomerController
    {
        // GET: Customer/Product
        public ActionResult Index()
        {

            return View();
        }
    }
}