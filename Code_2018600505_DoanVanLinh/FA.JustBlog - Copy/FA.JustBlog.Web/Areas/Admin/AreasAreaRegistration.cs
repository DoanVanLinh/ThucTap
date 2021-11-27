using System.Web.Mvc;

namespace FA.JustBlog.Areas.Areas
{
    public class AreasAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller = "Account", action = "Login", id = UrlParameter.Optional },
                new string[] { "FA.JustBlog.Areas.Admin.Controllers" }
                );
        }
    }
}