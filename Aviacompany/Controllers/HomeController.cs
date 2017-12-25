using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;
using Aviacompany.Library.Infrastrucutre;
using Aviacompany.Library.Models;
using Castle.Core.Internal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Aviacompany.Controllers
{
    public class HomeController : BaseController
    {
        private IFlightRepository _flightRepository;
        private ICityRepository _cityRepository;
        private ITeamEmployeeRepository _teamEmployeeRepository;
        private ITeamRepository _teamRepository;
        private IBrigadeRepository _brigadeRepository;

        
        public HomeController(IFlightRepository flightRepository, ICityRepository cityRepository, 
            ITeamEmployeeRepository teamEmployeeRepository, ITeamRepository teamRepository, 
            IBrigadeRepository brigadeRepository)
        {
            _flightRepository = flightRepository;
            _cityRepository = cityRepository;
            _teamEmployeeRepository = teamEmployeeRepository;
            _teamRepository = teamRepository;
            _brigadeRepository = brigadeRepository;
        }

        public ActionResult Index()
        {
            FlightsViewModel flightsViewModel = new FlightsViewModel();
            flightsViewModel.Flights = _flightRepository.Flights;
            flightsViewModel.Cities = _cityRepository.Cities;
            flightsViewModel.Date = null;
            return View(flightsViewModel);
        }

        [HttpPost]
        public ActionResult Search(FlightsViewModel flightsViewModel)
        {
            flightsViewModel.Cities = _cityRepository.Cities;
            flightsViewModel.Flights = _flightRepository.Flights;           
            if (!flightsViewModel.FlightName.IsNullOrEmpty())
                flightsViewModel.Flights =
                    flightsViewModel.Flights.Where(f => f.FlightNumber.ToLower().Contains(flightsViewModel.FlightName.ToLower()));
            if (flightsViewModel.CityTo != null)
                flightsViewModel.Flights =
                    flightsViewModel.Flights.Where(f => f.FlightToCity.CityId.Equals(flightsViewModel.CityTo));
            if (flightsViewModel.CityFrom != null)
                flightsViewModel.Flights =
                    flightsViewModel.Flights.Where(f => f.FlightFromCity.CityId.Equals(flightsViewModel.CityFrom));
            if (flightsViewModel.Date != null)
            {
                flightsViewModel.Flights = flightsViewModel.Flights.Where(f =>
                    f.FlightDate.Date.Equals(flightsViewModel.Date.Value.Date));
            }
            return View("Index", flightsViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        public async Task<ActionResult> FlightInfo(int flightId = 0)
        {
            
            FlightInfoViewModel flightInfoViewModel = new FlightInfoViewModel();
            flightInfoViewModel.Flight = _flightRepository.Flights.FirstOrDefault(f => f.FlightId == flightId);
            flightInfoViewModel.TeamEmployees = _teamEmployeeRepository.TeamEmployees;
            flightInfoViewModel.Teams = _teamRepository.Teams;
            flightInfoViewModel.Brigades = _brigadeRepository.Brigades;
            return View(flightInfoViewModel);
        }

    }
}