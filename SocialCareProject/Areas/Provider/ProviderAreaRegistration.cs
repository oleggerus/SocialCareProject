using System.Web.Mvc;

namespace SocialCareProject.Areas.Provider
{
    public class ProviderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Provider";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Provider_default",
                "Provider/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SocialCareProject.Areas.Provider.Controllers" }

            );
        }
    }
}