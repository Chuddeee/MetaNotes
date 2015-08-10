using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaNotes.App_Start
{
    public class MetaNotesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotesIndexModelBuilder>().AsSelf();
            builder.RegisterType<EditNoteModelBuilder>().AsSelf();
            builder.RegisterType<SaveNoteModelBuilder>().AsSelf();
        }
    }
}