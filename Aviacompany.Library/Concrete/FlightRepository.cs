using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class FlightRepository : IFlightRepository
    {
        AviaCompanyContext context = new AviaCompanyContext();

        public IEnumerable<Flight> Flights
        {
            get
            {
                context.Cities.Load();
                context.Flights.Load();
                context.FlightStatuses.Load();
                return context.Flights;
            }
        }

        public void SaveFlight(Flight flight)
        {
            if (flight.FlightId == 0)
            {
                Brigade brigade = new Brigade();
                BrigadeRepository repository = new BrigadeRepository();
                repository.SaveBrigade(brigade);
                flight.Brigade = brigade;
                context.Flights.Add(flight);
            }
            else
            {
                Flight dbEntry = context.Flights.Find(flight.FlightId);
                if (dbEntry != null)
                {
                    dbEntry.FlightFrom = flight.FlightFrom;
                    dbEntry.FlightTo = flight.FlightTo;
                    dbEntry.FlightStatusId = flight.FlightStatusId;
                    dbEntry.FlightNumber = flight.FlightNumber;
                    dbEntry.FlightDate = flight.FlightDate;
                    dbEntry.FlightTime = flight.FlightTime;
                    dbEntry.BrigadeId = flight.BrigadeId;
                }
            }
            context.SaveChanges();
        }

        public Flight DeleteFlight(int flightId)
        {
            Flight dbEntry = context.Flights.Find(flightId);
            if (dbEntry != null)
            {
                context.Flights.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}