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
    public class ResultJsonOptionController : Controller
    {
        IRepository<Result> repository;
        public ResultJsonOptionController(IRepository<Result> repos)
        {
            this.repository = repos;
        }

        public PartialViewResult ShowOptions()
        {
            ResultJsonOptionViewModel model = new ResultJsonOptionViewModel
            {
                ResultsId = repository.All().OrderBy(r => r.ResultId).Select(r => r.ResultId),
                ResultsPilotName = repository.All().OrderBy(r => r.Pilot.PilotLName).Select(r => r.Pilot.PilotLName).Distinct(),
                ResultsGrid = repository.All().OrderBy(r => r.ResultGrid).Select(r => r.ResultGrid).Distinct(),
                ResultsPoints = repository.All().OrderBy(r => r.ResultPoints).Select(r => r.ResultPoints).Distinct(),
                ResultsPosition = repository.All().OrderBy(r => r.ResultPosition).Select(r => r.ResultPosition).Distinct(),
                ResultsRaceName = repository.All().OrderBy(r => r.Race.RaceName).Select(r => r.Race.RaceName).Distinct(),
                ResultsStatus = repository.All().OrderBy(r => r.ResultStatus).Select(r => r.ResultStatus).Distinct()
            };
            return PartialView(model);
        }

        // GET: ResultJsonOption
        public ActionResult Index()
        {
            return View();
        }
    }
}