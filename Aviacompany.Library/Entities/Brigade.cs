using System.Collections.Generic;

namespace Aviacompany.Library.Entities
{
    public class Brigade
    {
        public int BrigadeId { get; set; }
        
        public int? PilotTeamId { get; set; }

        public Team PilotTeam { get; set; }

        public int? NavigatorTeamId { get; set; }

        public Team NavigatorTeam { get; set; }

        public int? OperatorTeamId { get; set; }

        public Team OperatorTeam { get; set; }

        public int? StewardessTeamId { get; set; }

        public Team StewardessTeam { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

    }
}