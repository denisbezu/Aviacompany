using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class FlightStatusRepository : IFlightStatusRepository
    {
        AviaCompanyContext context = new AviaCompanyContext();

        public IEnumerable<FlightStatus> FlightStatuses
        {
            get
            {
                context.FlightStatuses.Load();
                return context.FlightStatuses;
            }
        }
    }
}