using Autofac;
using MetaNotes.UI.Services;

namespace MetaNotes.Infrastructure.DependencyResolution
{
    public class UIServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotesIndexModelBuilder>().AsSelf();
            builder.RegisterType<EditNoteModelBuilder>().AsSelf();
        }
    }
}
