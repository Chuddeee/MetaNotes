using Infrastructure.Data.EF;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace MetaNotes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MetaNotesContext, MetaNotesEfConfiguration>());
            DependencyResolverConfig.Configure();
        }
    }
}
