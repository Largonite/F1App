using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain.Abstract;

namespace F1App.WebUI.Controllers
{
    public class ResultController : Controller
    {
        private IResultRepository repository;

        public ResultController(IResultRepository repos)
        {
            this.repository = repos;
        }

        public ViewResult List()
        {
            return View(repository.Results);
        }
        // GET: Result
        public ActionResult Index()
        {
            return View();
        }
    }
}