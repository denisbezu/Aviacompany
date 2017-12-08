using System.Collections.Generic;

namespace Aviacompany.Library.Entities
{
    public class TeamType
    {
        public int TeamTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}