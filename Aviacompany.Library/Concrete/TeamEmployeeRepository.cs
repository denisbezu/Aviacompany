using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class TeamEmployeeRepository : ITeamEmployeeRepository
    {
        AviaCompanyContext context = new AviaCompanyContext();


        public IEnumerable<TeamEmployee> TeamEmployees
        {
            get
            {
                context.Employees.Load();
                context.TeamEmployees.Load();
                return context.TeamEmployees;
            }
        }
    }
}