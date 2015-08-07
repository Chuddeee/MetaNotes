using Autofac;
using MetaNotes.Business.Services;
using MetaNotes.Infrastructure.Data.EF;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class BusinessServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<CryptographyUtility>().As<ICryptographyUtility>();

            builder.RegisterType<FindUserCommand>().As<ICommand<FindUserArgs, FindUserResult>>();
        }
    }
}
