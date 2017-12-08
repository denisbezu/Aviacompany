using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class CityRepository : ICityRepository
    {
        AviaCompanyContext context = new AviaCompanyContext();

        public IEnumerable<City> Cities
        {
            get
            {
                context.Cities.Load();
                return context.Cities;
            }
        }

        public void SaveCity(City city)
        {
            if (city.CityId == 0)
                context.Cities.Add(city);
            else
            {
                City dbEntry = context.Cities.Find(city.CityId);
                if (dbEntry != null)
                {
                    dbEntry.CityName = city.CityName;
                }
            }
            context.SaveChanges();
        }

        public City DeleteCity(int cityId)
        {
            City dbEntry = context.Cities.Find(cityId);
            if (dbEntry != null)
            {
                context.Cities.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}