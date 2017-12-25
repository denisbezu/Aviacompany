using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class FlightStatusRepository : IFlightStatusRepository
    {
        readonly AviaCompanyContext _context = new AviaCompanyContext();

        public IEnumerable<FlightStatus> FlightStatuses
        {
            get
            {
                _context.FlightStatuses.Load();
                return _context.FlightStatuses;
            }
        }

        public void SaveFlightStatus(FlightStatus flightStatus)
        {
            if (flightStatus.FlightStatusId == 0)
                _context.FlightStatuses.Add(flightStatus);
            else
            {
                FlightStatus dbEntry = _context.FlightStatuses.Find(flightStatus.FlightStatusId);
                if (dbEntry != null)
                {
                    dbEntry.StatusName = flightStatus.StatusName;
                }
            }
            _context.SaveChanges();
        }

        public FlightStatus DeleteFlightStatus(int flightStatusId)
        {
            FlightStatus dbEntry = _context.FlightStatuses.Find(flightStatusId);
            if (dbEntry != null)
            {
                _context.FlightStatuses.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}