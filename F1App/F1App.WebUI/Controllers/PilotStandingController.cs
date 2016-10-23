using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;

namespace F1App.WebUI.Controllers
{
    public class PilotStandingController : Controller
    {
        private IPilotStandingRepository repository;

        public PilotStandingController(IPilotStandingRepository repos)
        {
            this.repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.PilotStandigs);
        }

        // GET: PilotStanding
        public ActionResult Index()
        {
            return View();
        }
    }
}