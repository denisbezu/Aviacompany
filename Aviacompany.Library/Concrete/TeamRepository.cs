using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class TeamRepository : ITeamRepository
    {
        AviaCompanyContext context = new AviaCompanyContext();

        public IEnumerable<Team> Teams
        {
            get
            {
                context.Teams.Load();
                return context.Teams;
            }
        }
    }
}