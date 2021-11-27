using FA.JustBlog.Areas.Admin.Filters;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.Services.Comments;
using FA.JustBlog.Services.IPost;
using FA.JustBlog.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IPostService postService;

        public CommentsController(ICommentService commentService, IPostService postService)
        {
            this.commentService = commentService;
            this.postService = postService;
        }
        public ActionResult Index()
        {
            var comments = commentService.GetAll();
            return View(comments);
        }
        public ActionResult Details(int id)
        {
            var comment = commentService.GetDetailCommentById(id);
            return View(comment);
        }
        public ActionResult Create()
        {
            TempData["Posts"] = new SelectList(postService.GetAll(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateCommentViewModel request)
        {
            if (ModelState.IsValid)
            {

                var response = commentService.Create(request);
                if (response.IsSuccessed)
                {
                    TempData["Message"] = "Thêm thành công!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }
            TempData["Posts"] = new SelectList(postService.GetAll(), "Id", "Title");
            return View(request);
        }
        public ActionResult Edit(int id)
        {
            EditCommentViewModel comment = commentService.GetEditCommentById(id);
            TempData["Posts"] = new SelectList(postService.GetAll(), "Id", "Title");

            return View(comment);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditCommentViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = commentService.Edit(request);
                if (response.IsSuccessed)
                {
                    TempData["Message"] = "Sửa thành công!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }
            TempData["Posts"] = new SelectList(postService.GetAll(), "Id", "Title");

            return View(request);
        }
        public ActionResult Delete(int id)
        {
            DeleteCommentViewModel comment = commentService.GetDeleteCommentById(id);
            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(DeleteCommentViewModel request)
        {
            if (ModelState.IsValid)
            {
                var response = commentService.Delete(request);
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