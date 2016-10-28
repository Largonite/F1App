using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.WebUI.Models;
using F1App.Domain.Abstract;
using F1App.Domain;

namespace F1App.WebUI.Controllers
{
    public class PilotJsonOptionController : Controller
    {
        IRepository<Pilot> repository;

        public PilotJsonOptionController(IRepository<Pilot> repos)
        {
            this.repository = repos;
        }

        public PartialViewResult ShowOptions()
        {
            PilotJsonOptionsViewModel model = new PilotJsonOptionsViewModel
            {
                PilotsId = repository.All().OrderBy(p => p.PilotId).Select(p=>p.PilotId),
                PilotsNb = repository.All().OrderBy(p => p.PilotNumber).Select(p => p.PilotNumber),
                PilotsFName = repository.All().OrderBy(p => p.PilotFName).Select(p => p.PilotFName).Distinct(),
                PilotsLName = repository.All().OrderBy(p => p.PilotLName).Select(p => p.PilotLName).Distinct(),
                PilotsNationality = repository.All().OrderBy(p => p.PilotNationality).Select(p => p.PilotNationality).Distinct(),
                PilotsDOB = repository.All().OrderBy(p => p.PilotDOB).Select(p => p.PilotDOB).Distinct(),
                PilotsAbv = repository.All().OrderBy(p => p.PilotAbv).Select(p => p.PilotAbv),
                PilotsTeam = repository.All().OrderBy(p => p.Team.TeamName).Select(p => p.Team.TeamName).Distinct(),
                PilotsUrl = repository.All().OrderBy(p=>p.PilotId).Select(p=>p.PilotUrl)
            };
            return PartialView(model);
        }
    }
}