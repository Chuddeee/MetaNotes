using Autofac;
using MetaNotes.ModelBuilders;

namespace MetaNotes.App_Start
{
    public class MetaNotesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotesIndexModelBuilder>().AsSelf();
            builder.RegisterType<EditNoteModelBuilder>().AsSelf();
            builder.RegisterType<SaveNoteModelBuilder>().AsSelf();
            builder.RegisterType<LogsIndexModelBuilder>().AsSelf();
        }
    }
}