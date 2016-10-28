using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain;

namespace F1App.WebUI.Controllers
{
    public class ListController : Controller
    {
        private IRepository<Result> resultRepository;
        private IRepository<Pilot> pilotRepository;
        private IRepository<Team> teamRepository;
        private IRepository<TeamStanding> teamStandingRepository;
        private IRepository<PilotStanding> pilotStandingRepository;

        public ListController(IRepository<Result> resultRepository, IRepository<Pilot> pilotRepository, 
            IRepository<Team> teamRepository, IRepository<TeamStanding> teamStandingRepository, IRepository<PilotStanding> pilotStandingRepository)
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