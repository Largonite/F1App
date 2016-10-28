using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain;

namespace F1App.WebUI.Controllers
{
    public class TeamController : Controller
    {
        private IRepository<Team> repository;

        public TeamController(IRepository<Team> repos)
        {
            repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.All());
        }
        
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
    }
}