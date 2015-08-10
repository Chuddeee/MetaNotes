using Autofac;
using MetaNotes.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
