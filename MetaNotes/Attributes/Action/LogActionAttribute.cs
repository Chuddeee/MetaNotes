using MetaNotes.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MetaNotes.Attributes
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        private void Log(RouteData routeData)
        {
            var logger = DependencyResolver.Current.GetService<ILogger>();           
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("Userid = {0} controller:{1} action:{2}", UserId,
                controllerName, actionName);
            logger.Info(message, new Exception("sadfsdfsdf",new Exception("sdfdsf")));
        }

        protected Guid? UserId
        {
            get
            {
                Guid? userId = null;
                var autentication = HttpContext.Current.GetOwinContext().Authentication;

                if (autentication != null && autentication.User != null && autentication.User.Identity != null)
                {
                    var g = new Guid();
                    if (Guid.TryParse(autentication.User.Identity.GetUserId(), out g))
                    {
                        userId = g;
                    }
                }

                return userId;
            }
        }        
    }
}