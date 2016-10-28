using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using F1App.Domain.Abstract;
using F1App.Domain;
using System.Web.Mvc;

namespace F1App.WebUI.Controllers
{
    public class PilotController : Controller
    {
        private IRepository<Pilot> repository;

        public PilotController(IRepository<Pilot> repos)
        {
            repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.All());
        }
    }
}