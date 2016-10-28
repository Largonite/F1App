using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain;

namespace F1App.WebUI.Controllers
{
    public class TeamStandingController : Controller
    {
        IRepository<TeamStanding> repository;

        public TeamStandingController(IRepository<TeamStanding> repos)
        {
            this.repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.All());
        }

        // GET: TeamStanding
        public ActionResult Index()
        {
            return View();
        }
    }
}