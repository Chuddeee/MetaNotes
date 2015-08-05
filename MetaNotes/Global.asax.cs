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

            DependencyConfig.Configure();
            DbConfig.Configure();
        }
    }
}
