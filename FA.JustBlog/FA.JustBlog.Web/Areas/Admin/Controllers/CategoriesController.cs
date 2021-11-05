using System.Web.Mvc;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FA.JustBlog.Areas.Admin.Filters;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var category = categoryService.GetDetailCategoryById(id);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateCategoryViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = categoryService.Create(request);
                if (response.IsSuccessed)
                {
                    TempData["Message"] = "Thêm thành công!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }
            return View(request);
        }

        public ActionResult Edit(int id)
        {
            EditCategoryViewModel category = categoryService.GetEditCategoryById(id);
            return View(category);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditCategoryViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = categoryService.Edit(request);
                if (response.IsSuccessed)
                {
                    TempData["Message"] = "Sửa thành công!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }
            return View(request);
        }

        public ActionResult Delete(int id)
        {
            DeleteCategoryViewModel category = categoryService.GetDeleteCategoryById(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(DeleteCategoryViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = categoryService.Delete(request);
                if (response.IsSuccessed)
                {
                    TempData["Message"] = "Xóa thành công!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }
            return View(request);
        }
    }
}
