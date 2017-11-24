using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library
{
    public class DatabaseCreator
    {
        public void CreateDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AviaCompanyContext>());
            var cities = new List<City>()
            {
                new City(){CityId = 1, CityName = "Kharkov"}
            };
            using (var context = new AviaCompanyContext())
            {
                cities.ForEach(c => context.Cities.Add(c));
                context.SaveChanges();
            }
        }
    }
}