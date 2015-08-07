using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MetaNotes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyConfig.Configure();
            DbConfig.Configure();

            //раскомментировать для проверки локализации
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-us");   
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-us");  
        }
    }
}
