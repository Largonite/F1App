using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain.Concrete;
using F1App.Domain;
using System.Linq;
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace F1App.WebUI.Controllers
{
    public class ApiController : Controller
    {
        private IRepository<Result> resultRepository;
        private IRepository<Pilot> pilotRepository;
        private IRepository<Team> teamRepository;
        private IRepository<TeamStanding> teamStandingRepository;
        private IRepository<PilotStanding> pilotStandingRepository;

        public ApiController(BaseRepository<Result> resultRepository, BaseRepository<Pilot> pilotRepository,
            BaseRepository<Team> teamRepository, BaseRepository<TeamStanding> teamStandingRepository, BaseRepository<PilotStanding> pilotStandingRepository)
        {
            this.resultRepository = resultRepository;
            this.pilotRepository = pilotRepository;
            this.teamRepository = teamRepository;
            this.teamStandingRepository = teamStandingRepository;
            this.pilotStandingRepository = pilotStandingRepository;
        }
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }

        public void Pilot()
        {
            string id = Request.QueryString["PilotsId"];
            string nb = Request.QueryString["PilotsNb"];
            string fName = Request.QueryString["PilotsFName"];
            string lName = Request.QueryString["PilotsLName"];
            string nat = Request.QueryString["PilotsNationality"];
            string dob = Request.QueryString["PilotsDOB"];
            string abv = Request.QueryString["PilotsAbv"];
            string team = Request.QueryString["PilotsTeam"];

            var res = pilotRepository.All();

            if (!string.IsNullOrWhiteSpace(id))
            {
                int idR = Convert.ToInt32(id);
                res = res.Where(p => p.PilotId == idR);
            }
            if (!string.IsNullOrWhiteSpace(nb))
            {
                var nbR = Convert.ToInt32(nb);
                res = res.Where(p => p.PilotNumber == (int)nbR);
            }
            if (!string.IsNullOrWhiteSpace(fName))
            {
                res = res.Where(p => p.PilotFName == fName);
            }
            if (!string.IsNullOrWhiteSpace(lName))
            {
                res = res.Where(p => p.PilotLName == lName);
            }
            if (!string.IsNullOrWhiteSpace(nat))
            {
                res = res.Where(p => p.PilotNationality == nat);
            }
            if (!string.IsNullOrWhiteSpace(dob))
            {
                res = res.Where(p => p.PilotDOB == dob);
            }
            if (!string.IsNullOrWhiteSpace(abv))
            {
                res = res.Where(p => p.PilotAbv == abv);
            }
            if (!string.IsNullOrWhiteSpace(team))
            {
                var teamR = Convert.ToInt32(team);
                res = res.Where(p => p.TeamId == teamR);
            }

            Debug.WriteLine("Query : " + res);
            var result = res.OrderBy(p => p.PilotId).Select(p => new {
                id = p.PilotId,
                lastName = p.PilotLName,
                firstName = p.PilotFName,
                nationality = p.PilotNationality,
                dateOfBirth = p.PilotDOB,
                abreviation = p.PilotAbv,
                number = p.PilotNumber,
                url = p.PilotUrl,
                team = new
                {
                    id = p.TeamId,
                    name = p.Team.TeamName,
                    url = p.Team.TeamUrl
                }
            }).ToList();

            Response.ContentType = "application/json; charset=utf-8";
            Response.AddHeader("Content-Disposition", "inline;filename=\"pilot.json\"");

            var o = new { data = new { list = result } };

            Response.Write(JsonConvert.SerializeObject(o, Formatting.Indented));
        }

        public void Team()
        {
            string id = Request.QueryString["TeamsId"];
            string name = Request.QueryString["TeamsName"];
            string nat = Request.QueryString["TeamsNationality"];

            var res = teamRepository.All();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var teamId = Convert.ToInt32(id);
                res = res.Where(t => t.TeamId == teamId);
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                res = res.Where(t => t.TeamName == name);
            }
            if (!string.IsNullOrEmpty(nat))
            {
                res = res.Where(t => t.TeamNationality == nat);
            }


            var result = res.OrderBy(t => t.TeamId).Select(t => new
            {
                id = t.TeamId,
                name = t.TeamName,
                nationality = t.TeamNationality,
                url = t.TeamUrl,
                pilots = t.Pilots.Select(p=>new {id = p.PilotId,lastName = p.PilotLName,firstName = p.PilotFName })
            });
            

            Response.ContentType = "application/json; charset=utf-8";
            Response.AddHeader("Content-Disposition", "inline;filename=\"team.json\"");

            var o = new { data = new { list = result } };

            Response.Write(JsonConvert.SerializeObject(o, Formatting.Indented));
        }
    }
}