using System.Collections.Generic;

namespace Aviacompany.Library.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public virtual ICollection<TeamEmployee> TeamEmployees { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}