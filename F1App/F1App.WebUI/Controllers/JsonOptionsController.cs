using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain.Concrete;
using F1App.Domain;
using F1App.WebUI.Models;
using System.Linq;

namespace F1App.WebUI.Controllers
{
    public class JsonOptionsController : Controller
    {
        private IRepository<Result> resultRepository;
        private IRepository<Pilot> pilotRepository;
        private IRepository<Team> teamRepository;
        private IRepository<TeamStanding> teamStandingRepository;
        private IRepository<PilotStanding> pilotStandingRepository;

        public JsonOptionsController(IRepository<Result> resultRepository, IRepository<Pilot> pilotRepository,
            IRepository<Team> teamRepository, IRepository<TeamStanding> teamStandingRepository, IRepository<PilotStanding> pilotStandingRepository)
        {
            this.resultRepository = resultRepository;
            this.pilotRepository = pilotRepository;
            this.teamRepository = teamRepository;
            this.teamStandingRepository = teamStandingRepository;
            this.pilotStandingRepository = pilotStandingRepository;
        }

        public PartialViewResult ShowPilotOptions()
        {
            PilotJsonOptionsViewModel model = new PilotJsonOptionsViewModel
            {
                PilotsId = pilotRepository.All().OrderBy(p => p.PilotId).Select(p => p.PilotId),
                PilotsNb = pilotRepository.All().OrderBy(p => p.PilotNumber).Select(p => p.PilotNumber),
                PilotsFName = pilotRepository.All().OrderBy(p => p.PilotFName).Select(p => p.PilotFName).Distinct(),
                PilotsLName = pilotRepository.All().OrderBy(p => p.PilotLName).Select(p => p.PilotLName).Distinct(),
                PilotsNationality = pilotRepository.All().OrderBy(p => p.PilotNationality).Select(p => p.PilotNationality).Distinct(),
                PilotsDOB = pilotRepository.All().OrderBy(p => p.PilotDOB).Select(p => p.PilotDOB).Distinct(),
                PilotsAbv = pilotRepository.All().OrderBy(p => p.PilotAbv).Select(p => p.PilotAbv),
                PilotsTeam = pilotRepository.All().OrderBy(p => p.Team.TeamName).Select(p => p.Team.TeamName).Distinct(),
                PilotsUrl = pilotRepository.All().OrderBy(p => p.PilotId).Select(p => p.PilotUrl),
                PilotsTeamId = pilotRepository.All().OrderBy(p=>p.PilotId).Select(p=>p.Team.TeamId)
            };
            return PartialView(model);
        }
        public PartialViewResult ShowTeamOptions()
        {
            TeamJsonOptionsViewModel model = new TeamJsonOptionsViewModel
            {
                TeamsName = teamRepository.All().OrderBy(t => t.TeamName).Select(t => t.TeamName),
                TeamsId = teamRepository.All().OrderBy(t => t.TeamId).Select(t => t.TeamId),
                TeamsNationality = teamRepository.All().OrderBy(t => t.TeamNationality).Select(t => t.TeamNationality).Distinct(),
                TeamsUrl = teamRepository.All().OrderBy(t => t.TeamId).Select(t => t.TeamUrl)
            };

            return PartialView(model);
        }
        public PartialViewResult ShowPilotStandingOptions()
        {
            PilotStandingJsonOptionsViewModel model = new PilotStandingJsonOptionsViewModel
            {
                PilotStId = pilotStandingRepository.All().OrderBy(p => p.PilotId).Select(p => p.PilotId),
                PilotStSeason = pilotStandingRepository.All().OrderBy(p => p.StandingSeason).Select(p => p.StandingSeason).Distinct(),
                PilotStPosition = pilotStandingRepository.All().OrderBy(p => p.StandingPosition).Select(p => p.StandingPosition).Distinct(),
                PilotStPoints = pilotStandingRepository.All().OrderBy(p => p.StandingPoints).Select(p => p.StandingPoints).Distinct(),
                PilotStPilotName = pilotStandingRepository.All().OrderBy(p => p.Pilot.PilotLName).Select(p => p.Pilot.PilotLName).Distinct(),
                PilotStWins = pilotStandingRepository.All().OrderBy(p => p.StandingWins).Select(p => p.StandingWins).Distinct()
            };
            return PartialView(model);
        }
        public PartialViewResult ShowTeamStandingOptions()
        {
            TeamStandingJsonOptionViewModel model = new TeamStandingJsonOptionViewModel
            {
                TeamStId = teamStandingRepository.All().OrderBy(t => t.StandingId).Select(t => t.StandingId),
                TeamStPoints = teamStandingRepository.All().OrderBy(t => t.StandingPoints).Select(t => t.StandingPoints).Distinct(),
                TeamStPosition = teamStandingRepository.All().OrderBy(t => t.StandingPosition).Select(t => t.StandingPosition).Distinct(),
                TeamStSeason = teamStandingRepository.All().OrderBy(t => t.StandingSeason).Select(t => t.StandingSeason).Distinct(),
                TeamStTeamName = teamStandingRepository.All().OrderBy(t => t.Team.TeamName).Select(t => t.Team.TeamName).Distinct(),
                TeamStWins = teamStandingRepository.All().OrderBy(t => t.StandingWins).Select(t => t.StandingWins).Distinct()
            };
            return PartialView(model);
        }
        public PartialViewResult ShowResultOptions()
        {
            ResultJsonOptionViewModel model = new ResultJsonOptionViewModel
            {
                ResultsId = resultRepository.All().OrderBy(r => r.ResultId).Select(r => r.ResultId),
                ResultsPilotName = resultRepository.All().OrderBy(r => r.Pilot.PilotLName).Select(r => r.Pilot.PilotLName).Distinct(),
                ResultsGrid = resultRepository.All().OrderBy(r => r.ResultGrid).Select(r => r.ResultGrid).Distinct(),
                ResultsPoints = resultRepository.All().OrderBy(r => r.ResultPoints).Select(r => r.ResultPoints).Distinct(),
                ResultsPosition = resultRepository.All().OrderBy(r => r.ResultPosition).Select(r => r.ResultPosition).Distinct(),
                ResultsRaceName = resultRepository.All().OrderBy(r => r.Race.RaceName).Select(r => r.Race.RaceName).Distinct(),
                ResultsStatus = resultRepository.All().OrderBy(r => r.ResultStatus).Select(r => r.ResultStatus).Distinct()
            };
            return PartialView(model);
        }
    }
}