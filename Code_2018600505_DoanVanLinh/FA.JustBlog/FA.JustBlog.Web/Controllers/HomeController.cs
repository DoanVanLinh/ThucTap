using FA.JustBlog.Core;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [ChildActionOnly]
        public ActionResult _PartialNavigation()
        {
            var categories = categoryService.GetAll();
            return PartialView(categories);
        }
        public ActionResult Index()
        {
            return View();
        }


    }
}