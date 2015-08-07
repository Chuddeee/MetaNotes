using Autofac;
using MetaNotes.Infrastructure.Authentication;
using Microsoft.AspNet.Identity;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class InfrastructureIdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserStore>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<UserManager>().As<UserManager<ApplicationUser>>();
        }
    }
}
