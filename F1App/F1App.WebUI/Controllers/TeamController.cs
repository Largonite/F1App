using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;

namespace F1App.WebUI.Controllers
{
    public class TeamController : Controller
    {
        private ITeamRepository repository;

        public TeamController(ITeamRepository repos)
        {
            repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.Teams);
        }
        
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
    }
}