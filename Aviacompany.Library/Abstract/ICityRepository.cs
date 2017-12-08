using System.Collections;
using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Abstract
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get;}

        void SaveCity(City city);

        City DeleteCity(int cityId);
    }
}