using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Abstract
{
    public interface ITeamEmployeeRepository
    {
        IEnumerable<TeamEmployee> TeamEmployees { get; }
    }
}