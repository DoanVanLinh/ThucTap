using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Areas.Admin.Filters;
using FA.JustBlog.Core;
using FA.JustBlog.Services.Tags;
using FA.JustBlog.ViewModels.Tags;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class TagsController : Controller
    {
        private readonly ITagService tagService;

        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        public ActionResult Index()
        {
            var tags = tagService.GetAll();
            return View(tags);
        }
        public ActionResult Details(int id)
        {
            var tag = tagService.GetDetailTagById(id);
            return View(tag);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateTagViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = tagService.Create(request);
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
            EditTagViewModel tag = tagService.GetEditTagById(id);
            return View(tag);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditTagViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = tagService.Edit(request);
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
            DeleteTagViewModel tag = tagService.GetDeleteTagById(id);
            return View(tag);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(DeleteTagViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = tagService.Delete(request);
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
