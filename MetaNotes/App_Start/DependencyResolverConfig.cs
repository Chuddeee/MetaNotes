using Autofac;
using MetaNotes.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetaNotes
{
    public class DependencyResolverConfig
    {
        public static void Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DomainServicesAutofacModule());
            containerBuilder.Build();
            DependencyResolver.SetResolver(containerBuilder);
        }
    }
}