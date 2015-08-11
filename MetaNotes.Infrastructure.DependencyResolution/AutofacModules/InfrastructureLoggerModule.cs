using Autofac;
using MetaNotes.Infrastructure.Logger;
using MetaNotes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class InfrastructureLoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NlogLogger>().As<ILogger>();
        }
    }
}
