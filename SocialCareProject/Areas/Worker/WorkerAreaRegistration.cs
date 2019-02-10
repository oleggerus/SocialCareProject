using System.Web.Mvc;

namespace SocialCareProject.Areas.Worker
{
    public class WorkerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Worker";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Worker_default",
                "Worker/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SocialCareProject.Areas.Worker.Controllers" }
            );
        }
    }
}