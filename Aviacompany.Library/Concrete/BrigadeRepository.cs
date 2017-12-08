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
    }
}