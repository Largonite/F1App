using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.WebUI.Models;
using F1App.Domain;

namespace F1App.WebUI.Controllers
{
    public class TeamStandingJsonOptionController : Controller
    {
        IRepository<TeamStanding> repository;

        public TeamStandingJsonOptionController(IRepository<TeamStanding> repos)
        {
            this.repository = repos;
        }

        public PartialViewResult ShowOptions()
        {
            TeamStandingJsonOptionViewModel model = new TeamStandingJsonOptionViewModel
            {
                TeamStId = repository.All().OrderBy(t => t.StandingId).Select(t => t.StandingId),
                TeamStPoints = repository.All().OrderBy(t => t.StandingPoints).Select(t => t.StandingPoints).Distinct(),
                TeamStPosition = repository.All().OrderBy(t => t.StandingPosition).Select(t => t.StandingPosition).Distinct(),
                TeamStSeason = repository.All().OrderBy(t => t.StandingSeason).Select(t => t.StandingSeason).Distinct(),
                TeamStTeamName = repository.All().OrderBy(t => t.Team.TeamName).Select(t => t.Team.TeamName).Distinct(),
                TeamStWins = repository.All().OrderBy(t => t.StandingWins).Select(t => t.StandingWins).Distinct()
            };
            return PartialView(model);
        }

        // GET: TeamStandingJsonOption
        public ActionResult Index()
        {
            return View();
        }
    }
}