using FA.JustBlog.ViewModels;
using FA.JustBlog.ViewModels.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            HttpContext.Session.Add("USER", request.User);
            HttpContext.Session.Add("Role", "Admin");
            return RedirectToAction("Index", "Posts");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

    }
}