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
    public class ProjectSkillsController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: ProjectSkills
        public ActionResult Index()
        {
            var projectSkills = db.ProjectSkills.Include(p => p.Project).Include(p => p.Skill);
            return View(projectSkills.ToList());
        }

        // GET: ProjectSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSkill projectSkill = db.ProjectSkills.Find(id);
            if (projectSkill == null)
            {
                return HttpNotFound();
            }
            return View(projectSkill);
        }

        // GET: ProjectSkills/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName");
            return View();
        }

        // POST: ProjectSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectSkillID,SkillID,ProjectID,ProjectSkillLevel")] ProjectSkill projectSkill)
        {
            if (ModelState.IsValid)
            {
                db.ProjectSkills.Add(projectSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectSkill.ProjectID);
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName", projectSkill.SkillID);
            return View(projectSkill);
        }

        // GET: ProjectSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSkill projectSkill = db.ProjectSkills.Find(id);
            if (projectSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectSkill.ProjectID);
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName", projectSkill.SkillID);
            return View(projectSkill);
        }

        // POST: ProjectSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectSkillID,SkillID,ProjectID,ProjectSkillLevel")] ProjectSkill projectSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectSkill.ProjectID);
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName", projectSkill.SkillID);
            return View(projectSkill);
        }

        // GET: ProjectSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSkill projectSkill = db.ProjectSkills.Find(id);
            if (projectSkill == null)
            {
                return HttpNotFound();
            }
            return View(projectSkill);
        }

        // POST: ProjectSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectSkill projectSkill = db.ProjectSkills.Find(id);
            db.ProjectSkills.Remove(projectSkill);
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
