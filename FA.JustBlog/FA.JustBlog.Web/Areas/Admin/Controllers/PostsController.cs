using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.IPost;
using FA.JustBlog.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public PostsController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var posts = postService.GetAll();
            return View(posts);
        }
        public ActionResult Details(int id)
        {
            var post = postService.GetDetailPostById(id);
            return View(post);
        }
        public ActionResult Create()
        {
            TempData["Categories"] = new SelectList(categoryService.GetAll(),"Id","Name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreatePostViewModel request)
        {
            if (ModelState.IsValid)
            {
                
                var response = postService.Create(request);
                if (response.IsSuccessed)
                {
                    TempData["Message"] = "Thêm thành công!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }
            TempData["Categories"] = new SelectList(categoryService.GetAll(), "Id", "Name");
            return View(request);
        }
        static string oldTag;
        public ActionResult Edit(int id)
        {
            EditPostViewModel post = postService.GetEditPostById(id);
            oldTag = post.Tags;
            TempData["Categories"] = new SelectList(categoryService.GetAll(), "Id", "Name");
            return View(post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditPostViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = postService.Edit(request,oldTag);
                if (response.IsSuccessed)
                {
                    TempData["Message"] = "Sửa thành công!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }
            TempData["Categories"] = new SelectList(categoryService.GetAll(), "Id", "Name");
            return View(request);
        }
        public ActionResult Delete(int id)
        {
            DeletePostViewModel post = postService.GetDeletePostById(id);
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(DeletePostViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = postService.Delete(request);
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