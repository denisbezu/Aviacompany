using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Abstract
{
    public interface ITeamRepository
    {
        IEnumerable<Team> Teams { get; }
    }
}