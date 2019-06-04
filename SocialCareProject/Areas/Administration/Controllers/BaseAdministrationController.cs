﻿using SocialCareProject.Authentication;
using System.Web.Mvc;
using System.Web.Routing;

namespace SocialCareProject.Areas.Administration.Controllers
{
    [CustomAuthorize(Roles = "AdministrationRole, AdministrationLeadRole")]
    public abstract class BaseAdministrationController : Controller
    {
        protected virtual JsonResult CreateJsonResult(bool success, string redirect = null, object data = null,
            string message = null, string returnUrl = null)
        {
            return Json(new { success, redirect, data, message, returnUrl });
        }

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

            filterContext.ExceptionHandled = true;

            var result = RedirectToRoute(
                new RouteValueDictionary {
                    { "Controller", "Error" },
                    { "Action", "PageNotFound" },
                    { "Area", filterContext.RouteData.Values["area"].ToString() }
                });
            filterContext.Result = result;
            filterContext.Result.ExecuteResult(ControllerContext);
            base.OnException(filterContext);
        }


        protected ActionResult AccessDeniedView()
        {
            return RedirectToAction("AccessDenied", "Error", new { pageUrl = Request.RawUrl });
        }

        protected override void HandleUnknownAction(string actionName)
        {
            RedirectToAction("AccessDenied", "Error").ExecuteResult(ControllerContext);
        }

    }
}