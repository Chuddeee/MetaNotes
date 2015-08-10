using Autofac;
using MetaNotes.Business.Services;
using MetaNotes.Core.Services;
using MetaNotes.Infrastructure.Data.EF;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class BusinessServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<NoteService>().As<INoteService>();

            builder.RegisterType<CryptographyUtility>().As<ICryptographyUtility>();

            builder.RegisterType<FindUserCommand>().As<ICommand<FindUserArgs, FindUserResult>>();
            builder.RegisterType<EditNoteCommand>().As<ICommand<EditNoteArgs, EmptyCommandResult>>();
            builder.RegisterType<CreateNoteCommand>().As<ICommand<CreateNoteArgs, EmptyCommandResult>>();
            builder.RegisterType<DeleteNoteCommand>().As<ICommand<DeleteNoteArgs, EmptyCommandResult>>();
        }
    }
}
