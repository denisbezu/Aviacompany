using System.Collections.Generic;

namespace Aviacompany.Library.Entities
{
    public class Team
    {
        public int TeamId { get; set; }

        public int? TeamTypeId { get; set; }

        public TeamType TeamType { get; set; }

        public virtual ICollection<TeamEmployee> TeamEmployees { get; set; }

        public virtual ICollection<Brigade> Pilots { get; set; }

        public virtual ICollection<Brigade> Operators { get; set; }

        public virtual ICollection<Brigade> Navigators { get; set; }

        public virtual ICollection<Brigade> Stewardesses { get; set; }


    }
}