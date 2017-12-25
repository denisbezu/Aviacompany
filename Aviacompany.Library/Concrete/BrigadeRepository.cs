using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class BrigadeRepository : IBrigadeRepository
    {
        AviaCompanyContext context = new AviaCompanyContext();

        public IEnumerable<Brigade> Brigades
        {
            get
            {
                context.Brigades.Load();
                return context.Brigades.Local;
            }
        }

        public void SaveBrigade(Brigade brigade)
        {
            if (brigade.BrigadeId == 0)
                context.Brigades.Add(brigade);
            else
            {
                Brigade dbEntry = context.Brigades.Find(brigade.BrigadeId);
                if (dbEntry != null)
                {
                    dbEntry.NavigatorTeamId = brigade.NavigatorTeamId;
                    dbEntry.OperatorTeamId = brigade.OperatorTeamId;
                    dbEntry.PilotTeamId = brigade.PilotTeamId;
                    dbEntry.StewardessTeamId = brigade.StewardessTeamId;
                   
                }
            }
            context.SaveChanges();
        }
    }
}