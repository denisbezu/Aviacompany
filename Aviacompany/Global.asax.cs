﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Aviacompany.Infrastructure;
using Aviacompany.Library;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace Aviacompany
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            //DatabaseCreator creator = new DatabaseCreator();
            //creator.CreateDatabase();
        }
    }
}
