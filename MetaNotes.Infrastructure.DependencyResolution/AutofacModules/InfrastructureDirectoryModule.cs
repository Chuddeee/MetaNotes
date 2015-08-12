using Autofac;
using MetaNotes.Business.Services;
using MetaNotes.Infrastructure.Directory;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class InfrastructureDirectoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DirectoryManager>().As<IDirectoryManager>();
            builder.RegisterType<FileManager>().As<IFileManager>();
        }
    }
}
