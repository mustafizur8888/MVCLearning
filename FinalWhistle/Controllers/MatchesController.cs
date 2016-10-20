using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalWhistle.Models;

namespace FinalWhistle.Controllers
{
    public class MatchesController : Controller
    {
        readonly MatchRepository _repository = new MatchRepository();
        // GET: Matches
        public ActionResult Index()
        {
            return View(_repository.GetAll().OrderByDescending(m=>m.Timestamp));
        }

        public ActionResult Add()
        {
            var viewModel = new MatchViewModel();
            var repository = new TeamRepository();
            viewModel.HomTeams = repository.GetAllTeam().OrderBy(t => t.TeamName).ToList();
            viewModel.AwayTeams = repository.GetAllTeam().OrderBy(t => t.TeamName).ToList();
            viewModel.HomePoints = 0;
            viewModel.AwayPoints = 0;
            viewModel.Timestamp = DateTime.Today;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(MatchViewModel viewModel)
        {

            if (viewModel.AwayTeamId == viewModel.HomeTeamId)
            {
                return View(viewModel);
            }
            MatchRepository repository = new MatchRepository();
            repository.Add(viewModel);

            return RedirectToAction("Index");
        }
    }
}