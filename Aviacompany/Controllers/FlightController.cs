using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Abstract;

namespace Aviacompany.Controllers
{
    public class FlightController : Controller
    {
        private IFlightRepository _flightRepository;

        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        // GET: Flight
        public ActionResult Index()
        {
            return View(_flightRepository.Flights);
        }
    }
}