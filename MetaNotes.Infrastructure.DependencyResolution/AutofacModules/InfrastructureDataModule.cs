using Autofac;
using MetaNotes.Core.Services;
using MetaNotes.Infrastructure.Data.EF;
using System.Data.Entity;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class InfrastructureDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MetaNotesContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}
