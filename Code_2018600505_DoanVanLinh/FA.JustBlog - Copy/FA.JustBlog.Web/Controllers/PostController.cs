using FA.JustBlog.Services.IPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        public ActionResult Index()
        {
            var posts = postService.GetAll();
            return View(posts);
        }
        public ActionResult GetDetailPost(int id)
        {
            var post = postService.GetDetailPostById(id);
            return View(post);
        }
        public ActionResult GetLastesPost()
        {
            var post = postService.GetAll().OrderByDescending(p=>p.PostedOn);
            return View(post);
        }
        public ActionResult GetLastesDetailPost()
        {
            int id = postService.GetAll().OrderByDescending(p => p.PostedOn).FirstOrDefault().Id;
            return View(GetDetailPost(id));
        }
        [HttpGet]
        public ActionResult GetPostsByCategory(int? categoryId)
        {
            var posts = postService.GetAll().Where(p => p.CategoryId == categoryId);
            return View(posts);
        }
    }
}