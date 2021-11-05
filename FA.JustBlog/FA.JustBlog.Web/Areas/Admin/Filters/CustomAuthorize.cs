using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Filters
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.Session["USER"];
            if (user != null)
            {
                var role = HttpContext.Current.Session["ROLE"];

                if (role != null)
                {
                    if (Roles != role.ToString())
                    {
                        filterContext.Result = new RedirectResult("/Account/Login");
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }

        }
    }

}