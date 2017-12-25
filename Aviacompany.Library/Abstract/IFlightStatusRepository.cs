using System.Collections;
using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Abstract
{
    public interface IFlightStatusRepository
    {
        IEnumerable<FlightStatus> FlightStatuses { get; }

        void SaveFlightStatus(FlightStatus flightStatus);

        FlightStatus DeleteFlightStatus(int flightStatusId);
    }
}