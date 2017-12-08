using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.Entities;

namespace Aviacompany.Controllers
{
    public class FlightController : Controller
    {
        private IFlightRepository _flightRepository;
        private ICityRepository _cityRepository;
        private IFlightStatusRepository _flightStatusRepository;

        public FlightController(IFlightRepository flightRepository, ICityRepository cityRepository, IFlightStatusRepository flightStatusRepository)
        {
            _flightRepository = flightRepository;
            _cityRepository = cityRepository;
            _flightStatusRepository = flightStatusRepository;
            ViewBag.FlightTo = _cityRepository.Cities.ToList();
            ViewBag.FlightStatus = _flightStatusRepository.FlightStatuses.ToList();
        }
        // GET: Flight
        public ActionResult Index()
        {
            return View(_flightRepository.Flights);
        }

        public ActionResult CreateFlight()
        {
            return View("Edit", new Flight());
        }

        public ViewResult Edit(int flightId)
        {
            Flight flight = _flightRepository.Flights
                .FirstOrDefault(g => g.FlightId == flightId);
            return View(flight);
        }
        [HttpPost]
        public ActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                if (CheckForErrors(flight))
                {
                    _flightRepository.SaveFlight(flight);

                    return RedirectToAction("Index", "Home");
                }
                else
                    return View(flight);
            }
            else
            {
                CheckForErrors(flight);
                return View(flight);
            }
        }

        private bool CheckForErrors(Flight flight)
        {
            bool flag = true;
            if (flight.FlightDate.Date < DateTime.Parse("01/01/1900"))
            {
                ModelState.AddModelError("date", "Задайте дату больше, чем 01/01/1900");
                flag = false;
            }
            if(flight.FlightTo == null)
            {
                ModelState.AddModelError("flightTo", "Задайте поле \"Куда?\"");
                flag = false;
            }
            if (flight.FlightFrom == null)
            {
                ModelState.AddModelError("flightTo", "Задайте поле \"Откуда?\"");
                flag = false;
            }
            if (flight.FlightFrom != null && flight.FlightTo != null && flight.FlightFrom == flight.FlightTo)
            {
                ModelState.AddModelError("flightTo", "Города вылета и прилета не могут быть одинаковыми");
                flag = false;
            }
            return flag;
        }

        [HttpPost]
        public ActionResult Delete(int flightId)
        {
            Flight deletedFligt = _flightRepository.DeleteFlight(flightId);
            return RedirectToAction("Index", "Home");
        }
    }
}