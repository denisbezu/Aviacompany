using System;
using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Models
{
    public class FlightsViewModel
    {
        public IEnumerable<Flight> Flights { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public int? CityFrom { get; set; }

        public int? CityTo { get; set; }

        public string FlightName { get; set; }

        public DateTime? Date { get; set; }
    }
}