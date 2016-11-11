using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain.Concrete;
using F1App.Domain;
using F1App.WebUI.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

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

        [HttpGet]
        public ViewResult GenerateJson()
        {
            string id = Request.QueryString["PilotsId"];
            string nb = Request.QueryString["PilotsNb"] ;
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
            if(!string.IsNullOrWhiteSpace(nb ))
            {
                var nbR = Convert.ToInt32(nb);
                res = res.Where(p => p.PilotNumber == (int)nbR);
            }
            if(!string.IsNullOrWhiteSpace(fName))
            {
                res = res.Where(p => p.PilotFName == fName);
            }
            if(!string.IsNullOrWhiteSpace(lName))
            {
                res = res.Where(p => p.PilotLName == lName);
            }
            if(!string.IsNullOrWhiteSpace(nat))
            {
                res = res.Where(p => p.PilotNationality == nat);
            }
            if (!string.IsNullOrWhiteSpace(dob))
            {
                res = res.Where(p => p.PilotDOB == dob);
            }
            if(!string.IsNullOrWhiteSpace(abv))
            {
                res = res.Where(p => p.PilotAbv == abv);
            }
            if(!string.IsNullOrWhiteSpace(team))
            {
                var teamR = Convert.ToInt32(team);
                res = res.Where(p => p.TeamId == teamR);
            }

            Debug.WriteLine("Query : "+res);
            IEnumerable<Pilot> result = res.Select(p=>p).ToList();

            var jsonResult = JsonConvert.SerializeObject(result);

            //string jsonResult = serializer.Serialize(result);
            return View("GenerateJson",jsonResult);
        }
    }
}