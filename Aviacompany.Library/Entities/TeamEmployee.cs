using System.Threading.Tasks;
using Aviacompany.Library.Models;

namespace Aviacompany.Library.Entities
{
    public class TeamEmployee
    {
        public int TeamEmployeeId { get; set; }

        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}