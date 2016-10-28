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
    public class TeamJsonOptionController : Controller
    {
        private IRepository<Team> repository;

        public TeamJsonOptionController(IRepository<Team> repos)
        {
            this.repository = repos;
        }
        
        public PartialViewResult ShowOptions()
        {
            TeamJsonOptionsViewModel model = new TeamJsonOptionsViewModel
            {
                TeamsName = repository.All().OrderBy(t => t.TeamName).Select(t => t.TeamName),
                TeamsId = repository.All().OrderBy(t => t.TeamId).Select(t => t.TeamId),
                TeamsNationality = repository.All().OrderBy(t => t.TeamNationality).Select(t => t.TeamNationality).Distinct(),
                TeamsUrl = repository.All().OrderBy(t=>t.TeamId).Select(t=>t.TeamUrl)
            };

            return PartialView(model);
        }

    }
}