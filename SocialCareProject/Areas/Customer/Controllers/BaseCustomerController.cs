using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Services;

namespace SocialCareProject.Areas.Customer.Controllers
{


    [CustomAuthorize(Roles = "CustomerRole")]
    public abstract partial class BaseCustomerController : Controller
    {
        /// <summary>
        /// On exception
        /// </summary>
        /// <param name="filterContext">Filter context</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (Request.IsLocal) //don't run for local requests
            {
                base.OnException(filterContext);
                return;
            }

            Exception exception = filterContext.Exception;
            
            filterContext.ExceptionHandled = true;
            //var Result = RedirectToAction("Error", "Common");

            var result = RedirectToRoute(
                new RouteValueDictionary {
                    { "Controller", "Common" },
                    { "Action", "Error" },
                    { "Area", filterContext.RouteData.Values["area"].ToString() }
                });
            filterContext.Result = result;
            filterContext.Result.ExecuteResult(ControllerContext);
            base.OnException(filterContext);
        }

      
        protected ActionResult AccessDeniedView()
        {
            return RedirectToAction("AccessDenied", "Common", new { pageUrl = Request.RawUrl });
        }

        protected override void HandleUnknownAction(string actionName)
        {
            RedirectToAction("PageNotFound", "Common").ExecuteResult(ControllerContext);
        }

    }
}