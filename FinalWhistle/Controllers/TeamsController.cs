using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalWhistle.Models;

namespace FinalWhistle.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        private readonly TeamRepository _repository = new TeamRepository();
        public ActionResult Index()
        {

            return View(_repository.GetAllTeam().OrderBy(t => t.TeamName));
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Team team)
        {
            if (!string.IsNullOrWhiteSpace(team.TeamName))
            {
                var context = new FWContext();
                var queryable = context.Teams.AsQueryable().Where(t => t.TeamName.ToLower() == team.TeamName.ToLower());
                var any = queryable.ToList().Count;

                //checik team name is alreay use
                if (any > 0)
                {
                    ModelState.AddModelError("TeamName", "Name is already use");
                }
                else
                {
                    //save in db.

                    _repository.AddTeam(team);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("TeamName", "Team name is empty");
            }
            return View();
        }
    }
}