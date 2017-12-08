using System.Collections;
using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Abstract
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> Flights { get; }

        void SaveFlight(Flight flight);
        Flight DeleteFlight(int flightId);
    }
}