using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain.Concrete;
using F1App.Domain;
using System.Linq;
using System.Diagnostics;
using System;
using Newtonsoft.Json;

namespace F1App.WebUI.Controllers
{
    public class ListController : Controller
    {
        private IRepository<Result> resultRepository;
        private IRepository<Pilot> pilotRepository;
        private IRepository<Team> teamRepository;
        private IRepository<TeamStanding> teamStandingRepository;
        private IRepository<PilotStanding> pilotStandingRepository;

        public ListController(BaseRepository<Result> resultRepository, BaseRepository<Pilot> pilotRepository,
            BaseRepository<Team> teamRepository, BaseRepository<TeamStanding> teamStandingRepository, BaseRepository<PilotStanding> pilotStandingRepository)
        {
            this.resultRepository = resultRepository;
            this.pilotRepository = pilotRepository;
            this.teamRepository = teamRepository;
            this.teamStandingRepository = teamStandingRepository;
            this.pilotStandingRepository = pilotStandingRepository;
        }

        public ViewResult PilotList()
        {
            return View(pilotRepository.All());
        }

        public ViewResult TeamList()
        {
            return View(teamRepository.All());
        }

        public ViewResult ResultList()
        {
            return View(resultRepository.All());
        }
        public ViewResult PilotStandingList()
        {
            return View(pilotStandingRepository.All());
        }
        public ViewResult TeamStandingList()
        {
            return View(teamStandingRepository.All());
        }

    }
}