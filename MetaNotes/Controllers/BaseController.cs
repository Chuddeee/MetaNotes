using MetaNotes.Attributes;
using MetaNotes.Business.Services;
using MetaNotes.Infrastructure.Authentication;
using MetaNotes.UI.Model;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace MetaNotes.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Guid? UserId
        {
            get
            {
                Guid? result = null;
                var autentication = HttpContext.GetOwinContext().Authentication;

                if (autentication != null && autentication.User != null && autentication.User.Identity != null)
                {
                    var g = new Guid();
                    if(Guid.TryParse(autentication.User.Identity.GetUserId(), out g))
                    {
                        result = g;
                    }
                }

                return result;
            }
        }        
	}
}