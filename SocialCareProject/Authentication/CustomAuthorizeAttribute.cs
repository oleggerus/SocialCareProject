﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCareProject.Authentication
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {


        protected virtual CustomUser CurrentUser
        {
            get { return HttpContext.Current.User as CustomUser; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return ((CurrentUser == null || CurrentUser.IsInRole(Roles)) && CurrentUser != null);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (CurrentUser == null)
            {
                routeData = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                (new
                {
                    controller = "Home",
                    action = "Login",
                }
                ));
            }
            else
            {
                routeData = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                (new
                {
                    controller = "Error",
                    action = "AccessDenied",
                }
                ));
            }

            filterContext.Result = routeData;
        }

    }
}