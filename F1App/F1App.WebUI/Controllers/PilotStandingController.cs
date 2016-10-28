using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain;

namespace F1App.WebUI.Controllers
{
    public class PilotStandingController : Controller
    {
        private IRepository<PilotStanding> repository;

        public PilotStandingController(IRepository<PilotStanding> repos)
        {
            this.repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.All());
        }

        // GET: PilotStanding
        public ActionResult Index()
        {
            return View();
        }
    }
}