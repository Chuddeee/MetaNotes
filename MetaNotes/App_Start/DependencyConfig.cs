using Autofac;
using Autofac.Integration.Mvc;
using MetaNotes.Infrastructure.DependencyResolution;
using System.Web.Mvc;

namespace MetaNotes
{
    public class DependencyConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new InfrastructureDataModule());
            builder.RegisterModule(new BusinessServicesModule());
            builder.RegisterModule(new UIServicesModule());
            builder.RegisterModule(new ServicesModule());
             
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));                                 
        }
    }
}