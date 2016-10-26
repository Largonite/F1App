using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.WebUI.Models;
using F1App.Domain.Abstract;

namespace F1App.WebUI.Controllers
{
    public class PilotJsonOptionController : Controller
    {
        IPilotRepository repository;

        public PilotJsonOptionController(IPilotRepository repos)
        {
            this.repository = repos;
        }

        public PartialViewResult ShowOptions()
        {
            PilotJsonOptionsViewModel model = new PilotJsonOptionsViewModel
            {
                PilotsId = repository.Pilots.OrderBy(p => p.PilotId).Select(p => p.PilotId),
                PilotsNb = repository.Pilots.OrderBy(p => p.PilotNumber).Select(p => p.PilotNumber),
                PilotsFName = repository.Pilots.OrderBy(p => p.PilotFName).Select(p => p.PilotFName).Distinct(),
                PilotsLName = repository.Pilots.OrderBy(p => p.PilotLName).Select(p => p.PilotLName).Distinct(),
                PilotsNationality = repository.Pilots.OrderBy(p => p.PilotNationality).Select(p => p.PilotNationality).Distinct(),
                PilotsDOB = repository.Pilots.OrderBy(p => p.PilotDOB).Select(p => p.PilotDOB).Distinct(),
                PilotsAbv = repository.Pilots.OrderBy(p => p.PilotAbv).Select(p => p.PilotAbv),
                PilotsTeam = repository.Pilots.OrderBy(p => p.Team.TeamName).Select(p => p.Team.TeamName).Distinct()
            };
            return PartialView(model);
        }
    }
}