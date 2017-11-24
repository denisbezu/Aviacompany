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
                context.FlightStatuses.Load();
                return context.Flights;
            }
        }


    }
}