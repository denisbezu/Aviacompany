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
        }
    }
}