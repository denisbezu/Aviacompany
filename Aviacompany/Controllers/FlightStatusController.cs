using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.Entities;
using Microsoft.AspNet.Identity;

namespace Aviacompany.Controllers
{
    public class FlightStatusController : BaseController
    {
        private IFlightStatusRepository _flightStatusRepository;

        public FlightStatusController(IFlightStatusRepository flightStatusRepository)
        {
            _flightStatusRepository = flightStatusRepository;
        }
        // GET: City
        public ActionResult Index()
        {
            return View(_flightStatusRepository.FlightStatuses);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                _flightStatusRepository.SaveFlightStatus(new FlightStatus() { StatusName = name });
                return RedirectToAction("Index");
            }
            return View(name);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        public ActionResult Delete(int flightStatusId)
        {
            FlightStatus deletedFligt = _flightStatusRepository.DeleteFlightStatus(flightStatusId);
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int flightStatusId)
        {
            FlightStatus flightStatus = _flightStatusRepository.FlightStatuses
                .FirstOrDefault(g => g.FlightStatusId == flightStatusId);
            return View(flightStatus);
        }

        [HttpPost]
        public ActionResult Edit(FlightStatus flightStatus)
        {
            if (ModelState.IsValid)
            {
                _flightStatusRepository.SaveFlightStatus(flightStatus);
                return RedirectToAction("Index");
            }
            return View(flightStatus);
        }
    }
}