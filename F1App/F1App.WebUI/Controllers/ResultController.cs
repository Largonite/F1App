using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;
using F1App.Domain;

namespace F1App.WebUI.Controllers
{
    public class ResultController : Controller
    {
        private IRepository<Result> resultRepository;

        public ResultController(IRepository<Result> repos)
        {
            this.resultRepository = repos;
        }

        public ViewResult List()
        {
            return View(resultRepository.All());
        }
        // GET: Result
        public ActionResult Index()
        {
            return View();
        }
    }
}