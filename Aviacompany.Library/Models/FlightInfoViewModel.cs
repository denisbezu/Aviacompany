using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Models
{
    public class FlightInfoViewModel
    {
        public Flight Flight { get; set; }

        public IEnumerable<TeamEmployee> TeamEmployees { get; set; }

        public IEnumerable<Team> Teams { get; set; }

        public IEnumerable<Brigade>  Brigades { get; set; }
    }
}