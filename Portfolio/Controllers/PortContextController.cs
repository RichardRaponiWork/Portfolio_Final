using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class PortContextController : Controller
    {
        // GET: PortContext

        //public ActionResult Index()
        //{
        //    PortfolioEntities cs = new PortfolioEntities();
        //    List<Skill> MySkill = cs.Skills.ToList();
        //    List<ProjectSkill> MyTag = cs.ProjectSkills.ToList();
        //    List<Project> MyProject = cs.Projects.ToList();
        //    return View();
        //}

        public ActionResult ProjectByTag(int ID)
        {
            PortfolioEntities cs = new PortfolioEntities();
            List<ProjectTag> MyProjectTag = cs.ProjectTags.Where(s => s.TagID == ID).ToList();
            return View(MyProjectTag);
        }


        public ActionResult ProjectBySkill(int ID)
        {
            PortfolioEntities cs = new PortfolioEntities();
            List<ProjectSkill> ProjectsBySkill = cs.ProjectSkills.Where(s=> s.SkillID == ID).ToList();
            return View(ProjectsBySkill);
        }

        public ActionResult ProjectSkill1()
        {
            PortfolioEntities cs = new PortfolioEntities();
            List<ProjectSkill> MyProjectSkill = cs.ProjectSkills.ToList();
            return View(MyProjectSkill);
        }
        public ActionResult Skill1()
        {
            PortfolioEntities cs = new PortfolioEntities();
            List<Skill> MySkill = cs.Skills.ToList();
            return View(MySkill);
        }

        public ActionResult Tag()
        {
            PortfolioEntities cs = new PortfolioEntities();
            List<Tag> MyTag = cs.Tags.ToList();
            return View(MyTag);
        }

        public ActionResult ProjectTag()
        {
            PortfolioEntities cs = new PortfolioEntities();
            List<ProjectTag> MyProjectTag = cs.ProjectTags.ToList();
            return View(MyProjectTag);
        }

        //public ActionResult AboutMe()
        //{
        //    //PortfolioEntities cs = new PortfolioEntities();
        //    //List<ProjectTag> MyProjectTag = cs.ProjectTags.ToList();
        //    return View(AboutMe);
        //}
    }
}