using System.Linq;
using System.Web.Mvc;
using F1App.Domain;
using F1App.Domain.Abstract;

namespace F1App.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Result> resultRepository;
        private IRepository<Pilot> pilotRepository;
        private IRepository<Team> teamRepository;
        private IRepository<TeamStanding> teamStandingRepository;
        private IRepository<PilotStanding> pilotStandingRepository;

        public AdminController(IRepository<Result> resultRepository, IRepository<Pilot> pilotRepository,
            IRepository<Team> teamRepository, IRepository<TeamStanding> teamStandingRepository, IRepository<PilotStanding> pilotStandingRepository)
        {
            this.resultRepository = resultRepository;
            this.pilotRepository = pilotRepository;
            this.teamRepository = teamRepository;
            this.teamStandingRepository = teamStandingRepository;
            this.pilotStandingRepository = pilotStandingRepository;
        }

        /**
         * 
         * LIST VIEWS
         * 
         */

        public ViewResult PilotListAdmin()
        {
            return View(pilotRepository.All());
        }
        public ViewResult TeamListAdmin()
        {
            return View(teamRepository.All());
        }
        public ViewResult ResultListAdmin()
        {
            return View(resultRepository.All());
        }
        public ViewResult PilotStandingListAdmin()
        {
            return View(pilotStandingRepository.All());
        }
        public ViewResult TeamStandingListAdmin()
        {
            return View(teamStandingRepository.All());
        }

        /**
         * 
         * PILOT ACTIONS
         * 
         */

        [HttpPost]
        public string SavePilot(Pilot pilot)
        {
            Save(pilotRepository, pilot.PilotId,pilot, string.Format("{0} {1} has been saved", pilot.PilotFName, pilot.PilotLName), "Impossible to update the pilot! ");
            return "PilotListAdmin";
        }

        [HttpPost]
        public ActionResult AddPilot(Pilot pilot)
        {
            Save(pilotRepository, pilot.PilotId, pilot, string.Format("{0} {1} has been saved", pilot.PilotFName, pilot.PilotLName), "Impossible to update the pilot! ");
            return RedirectToAction("PilotListAdmin");
        }

        [HttpGet]
        public ActionResult DeletePilot(int pilotId)
        {
            Pilot p = pilotRepository.Delete(pilotId);
            if (p != null)
            {
                TempData["SuccessMessage"] = string.Format("{0} {1} has been deleted", p.PilotFName, p.PilotLName);
            }
            else
            {
                TempData["ErrorMessage"] = "Impossible to delete the pilot!";
            }
            return RedirectToAction("PilotListAdmin");
        }

        /**
         * 
         * TEAM ACTIONS
         * 
         */

        [HttpPost]
        public string SaveTeam(Team team)
        {
            Save(teamRepository, team.TeamId, team, string.Format("Team {0} has been saved", team.TeamName), "Impossible to update the Team");
            return "TeamListAdmin";
        }

        [HttpPost]
        public ActionResult AddTeam(Team team)
        {
            Save(teamRepository, team.TeamId, team, string.Format("Team {0} has been saved", team.TeamName), "Impossible to update the Team");
            return new RedirectResult("TeamListAdmin");
        }

        [HttpGet]
        public ActionResult DeleteTeam(int teamId)
        {
            Team t = teamRepository.Delete(teamId);
            if (t != null)
            {
                TempData["SuccessMessage"] = string.Format("{0} has been deleted", t.TeamName);
            }
            else
            {
                TempData["ErrorMessage"] = "Impossible to delete the team! Check the Teams_pilot FK";
            }
            return RedirectToAction("TeamListAdmin");
        }

        private void Save<T>(IRepository<T> repository,int id, T o,string successMsg, string errorMsg)
        {
            if (ModelState.IsValid)
            {
                if (repository.Save(id, o))
                {
                    TempData["SuccessMessage"] = successMsg;//string.Format("{0} {1} has been saved", pilot.PilotFName, pilot.PilotLName);
                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
                string err = "";
                foreach (var e in errors)
                {
                    err += e[0].ErrorMessage + "\n";
                }
                TempData["ErrorMessage"] = errorMsg + err;//"Impossible to update the pilot! " + err;
            }
        }
    }
}
