using Autofac;
using Domain.Services;
using Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetaNotes.Autofac
{
    public class DomainServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MetaNotesContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}