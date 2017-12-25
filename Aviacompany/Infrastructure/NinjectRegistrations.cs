using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.Concrete;
using Aviacompany.Library.Entities;
using Moq;
using Ninject;
using Ninject.Modules;

namespace Aviacompany.Infrastructure
{

    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            ModelValidatorProviders.Providers.Clear();
            Bind<IFlightRepository>().To<FlightRepository>();
            Bind<ICityRepository>().To<CityRepository>();
            Bind<IFlightStatusRepository>().To<FlightStatusRepository>();
            Bind<ITeamEmployeeRepository>().To<TeamEmployeeRepository>();
            Bind<ITeamRepository>().To<TeamRepository>();
            Bind<IBrigadeRepository>().To<BrigadeRepository>();
            Bind<IRequestRepositiry>().To<RequestRepository>();
        }
    }
}