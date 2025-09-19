using System.Web.Mvc;

namespace CafeMenuProject.WebUI.Areas.Admin
{
    /// <summary>
    /// Admin area registration
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: "admin_default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
