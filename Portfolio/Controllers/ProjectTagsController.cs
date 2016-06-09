using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectTagsController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: ProjectTags
        public ActionResult Index()
        {
            var projectTags = db.ProjectTags.Include(p => p.Project).Include(p => p.Tag);
            return View(projectTags.ToList());
        }

        // GET: ProjectTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTag projectTag = db.ProjectTags.Find(id);
            if (projectTag == null)
            {
                return HttpNotFound();
            }
            return View(projectTag);
        }

        // GET: ProjectTags/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName");
            return View();
        }

        // POST: ProjectTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectTagID,TagID,ProjectID")] ProjectTag projectTag)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTags.Add(projectTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectTag.ProjectID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName", projectTag.TagID);
            return View(projectTag);
        }

        // GET: ProjectTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTag projectTag = db.ProjectTags.Find(id);
            if (projectTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectTag.ProjectID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName", projectTag.TagID);
            return View(projectTag);
        }

        // POST: ProjectTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectTagID,TagID,ProjectID")] ProjectTag projectTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectTag.ProjectID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName", projectTag.TagID);
            return View(projectTag);
        }

        // GET: ProjectTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTag projectTag = db.ProjectTags.Find(id);
            if (projectTag == null)
            {
                return HttpNotFound();
            }
            return View(projectTag);
        }

        // POST: ProjectTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTag projectTag = db.ProjectTags.Find(id);
            db.ProjectTags.Remove(projectTag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
