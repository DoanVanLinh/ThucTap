using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.Controllers
{
    public class PostsController : Controller
    {
        //
        private static JustBlogContext dbContext = new JustBlogContext();
        private static IUnitOfWork unitOfWork = new UnitOfWork(dbContext);

        public ActionResult Index()
        {
            var posts = unitOfWork.PostRepository.GetAll().Where(p => p.Status != Models.Enums.Status.IsDeleted).ToList();
            return View(posts);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = unitOfWork.PostRepository.Find(p => p.Id == id).FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(dbContext.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PostRepository.Add(post);
                unitOfWork.SaveChange();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(dbContext.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = unitOfWork.PostRepository.Find(p => p.Id == id).FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(dbContext.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PostRepository.Update(post);
                unitOfWork.SaveChange();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(dbContext.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = unitOfWork.PostRepository.Find(p => p.Id == id).FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = unitOfWork.PostRepository.Find(p => p.Id == id).FirstOrDefault();
            unitOfWork.PostRepository.Delete(post);
            unitOfWork.SaveChange();
            return RedirectToAction("Index");
        }
    }
}
