using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using F1App.Domain.Abstract;
using System.Web.Mvc;

namespace F1App.WebUI.Controllers
{
    public class PilotController : Controller
    {
        private IPilotRepository repository;

        public PilotController(IPilotRepository repos)
        {
            repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.Pilots);
        }

        // GET: Pilot
        public ActionResult Index()
        {
            return View();
        }
    }
}