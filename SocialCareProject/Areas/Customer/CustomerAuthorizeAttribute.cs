using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DataRepository.Enums;
using DataRepository.RepositoryPattern;
using Services;
using Services.Address;
using Services.Administration;
using Services.Assignments;
using Services.Offer;
using Services.People;
using Services.Product;
using Services.Vendor;
using SocialCareProject.Authentication;

namespace SocialCareProject.Areas.Customer
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return ((CurrentUser != null && !CurrentUser.IsInRole(Roles)) || CurrentUser == null) ? false : true;
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
                        controller = "Account",
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
                        action = "AccessDenied"
                    }
                ));
            }

            filterContext.Result = routeData;
        }

    }


    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    //public class CustomerAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    //{
    //    private readonly bool _dontValidate;
    //    private readonly IRoleService _roleService;
    //    private readonly IAuthenticationService _authenticationService;


    //    public CustomerAuthorizeAttribute(IRoleService roleService, IAuthenticationService authenticationService)
    //        : this(false, roleService, authenticationService)
    //    {

    //    }

    //    public CustomerAuthorizeAttribute(bool dontValidate, IRoleService roleService, IAuthenticationService authenticationService)
    //    {




    //        _roleService = roleService;
    //        _authenticationService = authenticationService;
    //    }

    //    public void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        if (_dontValidate)
    //        {
    //            return;
    //        }

    //        if (filterContext == null)
    //        {
    //            throw new ArgumentNullException(nameof(filterContext));
    //        }

    //        if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
    //        {
    //            throw new InvalidOperationException("You cannot use [CouncilAuthorize] attribute when a child action cache is active");
    //        }

    //        if (IsAdminPageRequested(filterContext) && !HasAdminAccess(filterContext))
    //        {
    //            HandleUnauthorizedRequest(filterContext);
    //        }
    //    }

    //    public virtual bool HasAdminAccess(AuthorizationContext filterContext)
    //    {
    //        var currentUser = _authenticationService.GetAuthenticatedCustomer();
    //        var allowedAreas = _roleService.GeAllowedAreasByUserId(currentUser.Id);
    //        return allowedAreas.Contains((int)AreaTypes.Customer);
    //    }

    //    private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    //    {
    //        if (filterContext.HttpContext.Request.IsAjaxRequest())
    //        {
    //            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
    //            filterContext.HttpContext.Response.End();
    //            return;
    //        }

    //        var loginPageUrl = new UrlHelper(filterContext.RequestContext).RouteUrl("Admin_Login", new { returnUrl = filterContext.HttpContext.Request.RawUrl });
    //        filterContext.Result = new RedirectResult(loginPageUrl);
    //    }

    //    private IEnumerable<CustomerAuthorizeAttribute> GetAdminAuthorizeAttributes(ActionDescriptor descriptor)
    //    {
    //        return descriptor.GetCustomAttributes(typeof(CustomerAuthorizeAttribute), true)
    //            .Concat(descriptor.ControllerDescriptor.GetCustomAttributes(typeof(CustomerAuthorizeAttribute), true))
    //            .OfType<CustomerAuthorizeAttribute>();
    //    }

    //    private bool IsAdminPageRequested(AuthorizationContext filterContext)
    //    {
    //        var adminAttributes = GetAdminAuthorizeAttributes(filterContext.ActionDescriptor);
    //        return adminAttributes != null && adminAttributes.Any();
    //    }
    //}
}