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
    public class PilotStandingJsonOptionController : Controller
    {
        IRepository<PilotStanding> repository;

        public PilotStandingJsonOptionController(IRepository<PilotStanding> repos)
        {
            this.repository = repos;
        }

        public PartialViewResult ShowOptions()
        {
            PilotStandingJsonOptionsViewModel model = new PilotStandingJsonOptionsViewModel
            {
                PilotStId = repository.All().OrderBy(p => p.PilotId).Select(p => p.PilotId),
                PilotStSeason = repository.All().OrderBy(p => p.StandingSeason).Select(p => p.StandingSeason).Distinct(),
                PilotStPosition = repository.All().OrderBy(p => p.StandingPosition).Select(p => p.StandingPosition).Distinct(),
                PilotStPoints = repository.All().OrderBy(p => p.StandingPoints).Select(p => p.StandingPoints).Distinct(),
                PilotStPilotName = repository.All().OrderBy(p => p.Pilot.PilotLName).Select(p => p.Pilot.PilotLName).Distinct(),
                PilotStWins = repository.All().OrderBy(p => p.StandingWins).Select(p => p.StandingWins).Distinct()
            };
            return PartialView(model);
        }

        // GET: PilotStandingJsonOption
        public ActionResult Index()
        {
            return View();
        }
    }
}