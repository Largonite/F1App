using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.WebUI.Models;

namespace F1App.WebUI.Controllers
{
    public class TeamJsonOptionController : Controller
    {
        private ITeamRepository repository;

        public TeamJsonOptionController(ITeamRepository repos)
        {
            this.repository = repos;
        }
        
        public PartialViewResult ShowOptions()
        {
            TeamJsonOptionsViewModel model = new TeamJsonOptionsViewModel
            {
                TeamsName = repository.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName),
                TeamsId = repository.Teams.OrderBy(t => t.TeamId).Select(t => t.TeamId),
                TeamsNationality = repository.Teams.OrderBy(t => t.TeamNationality).Select(t => t.TeamNationality).Distinct()
            };

            return PartialView(model);
        }

    }
}