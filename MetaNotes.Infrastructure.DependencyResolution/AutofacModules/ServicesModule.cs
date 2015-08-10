using Autofac;
using MetaNotes.Infrastructure.Mapping;
using MetaNotes.Services;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutoMapper>().As<IMapper>();
        }
    }
}
