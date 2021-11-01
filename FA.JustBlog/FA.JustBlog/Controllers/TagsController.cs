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

namespace FA.JustBlog.Controllers
{
    public class TagsController : Controller
    {
        private static JustBlogContext dbContext = new JustBlogContext();
        private static IUnitOfWork unitOfWork = new UnitOfWork(dbContext);

        public ActionResult Index()
        {
            var tags = unitOfWork.TagRepository.GetAll().Where(p => p.Status != Models.Enums.Status.IsDeleted).ToList();
            return View(tags);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = unitOfWork.TagRepository.Find(t => t.Id == id).FirstOrDefault();
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TagRepository.Add(tag);
                unitOfWork.SaveChange();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = unitOfWork.TagRepository.Find(t => t.Id == id).FirstOrDefault();
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(tag).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = unitOfWork.TagRepository.Find(t => t.Id == id).FirstOrDefault();
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = unitOfWork.TagRepository.Find(t => t.Id == id).FirstOrDefault();
            unitOfWork.TagRepository.Delete(tag);
            unitOfWork.SaveChange();
            return RedirectToAction("Index");
        }
    }
}
