﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1App.Domain;
using F1App.Domain.Abstract;
using F1App.Domain.Concrete;

namespace F1App.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Result> resultRepository;
        private IRepository<Pilot> pilotRepository;
        private IRepository<Team> teamRepository;
        private IRepository<TeamStanding> teamStandingRepository;
        private IRepository<PilotStanding> pilotStandingRepository;

        public AdminController(BaseRepository<Result> resultRepository, BaseRepository<Pilot> pilotRepository,
            BaseRepository<Team> teamRepository, BaseRepository<TeamStanding> teamStandingRepository, BaseRepository<PilotStanding> pilotStandingRepository)
        {
            this.resultRepository = resultRepository;
            this.pilotRepository = pilotRepository;
            this.teamRepository = teamRepository;
            this.teamStandingRepository = teamStandingRepository;
            this.pilotStandingRepository = pilotStandingRepository;
        }

        public ViewResult PilotListAdmin()
        {
            return View(pilotRepository.All());
        }

        /*public ViewResult EditPilot(int pilotId)
        {
            Pilot pilot = pilotRepository.GetById(pilotId);
            return View(pilot);
        }*/

        public ViewResult TeamListAdmin()
        {
            return View(teamRepository.All());
        }

        public ViewResult ResultListAdmin()
        {
            return View(resultRepository.All());
        }
        public ViewResult PilotStandingListAdmin()
        {
            return View(pilotStandingRepository.All());
        }
        public ViewResult TeamStandingListAdmin()
        {
            return View(teamStandingRepository.All());
        }

        [HttpPost]
        public ActionResult EditPilot(Pilot pilot)
        {
            if (ModelState.IsValid)
            {
                if (pilotRepository.Update(pilot.PilotId, pilot))
                {
                    TempData["SuccessMessage"] = string.Format("{0} {1} has been saved", pilot.PilotFName, pilot.PilotLName);
                }

            }else
            {
                TempData["ErrorMessage"] = "Impossible to update the pilot!";
            }
            return RedirectToAction("PilotListAdmin");
        }

        [HttpGet]
        public ActionResult DeletePilot(int pilotId)
        {
            Pilot p = pilotRepository.Delete(pilotId);
            if (p != null)
            {
                TempData["SuccessMessage"] = string.Format("{0} {1} has been deleted", p.PilotFName, p.PilotLName);
            }
            else
            {
                TempData["ErrorMessage"] = "Impossible to delete the pilot!";
            }
            return RedirectToAction("PilotListAdmin");
        }
    }
}
