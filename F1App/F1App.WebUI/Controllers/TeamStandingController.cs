using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;

namespace F1App.WebUI.Controllers
{
    public class TeamStandingController : Controller
    {
        ITeamStandingRpository repository;

        public TeamStandingController(ITeamStandingRpository repos)
        {
            this.repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.TeamStandings);
        }

        // GET: TeamStanding
        public ActionResult Index()
        {
            return View();
        }
    }
}