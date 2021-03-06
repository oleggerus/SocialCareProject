﻿using Newtonsoft.Json;
using SocialCareProject.Authentication;
using SocialCareProject.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace SocialCareProject
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependencyConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);


                    var serializeModel = JsonConvert.DeserializeObject<UserModel>(authTicket.UserData);

                    var principal = new CustomUser(authTicket.Name)
                    {
                        UserId = serializeModel.UserId,
                        FirstName = serializeModel.FirstName,
                        LastName = serializeModel.LastName,
                        AreaId = serializeModel.AreaId,
                        Roles = serializeModel.RoleName.ToArray<string>()
                    };

                    HttpContext.Current.User = principal;
                }
                catch (CryptographicException)
                {
                    FormsAuthentication.SignOut();
                }


            }

        }
    }
}
