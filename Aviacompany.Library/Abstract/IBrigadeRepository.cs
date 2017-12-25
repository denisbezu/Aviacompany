using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Abstract
{
    public interface IBrigadeRepository
    {
        IEnumerable<Brigade> Brigades { get; }

        void SaveBrigade(Brigade brigade);
    }
}