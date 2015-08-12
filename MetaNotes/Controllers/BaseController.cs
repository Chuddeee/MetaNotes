using MetaNotes.Common;
using MetaNotes.Core.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    public abstract class BaseController : Controller
    {
        protected async Task<User> GetUser()
        {
            if(Session[KeysConstants.UserSessionKey]!=null)
            {
                return Session[KeysConstants.UserSessionKey] as User;
            }

            var userId = GetUserId();
            if (!userId.HasValue)
                return null;
        }

        protected Guid? GetUserId()
        {
            Guid? result = null;
            var autentication = HttpContext.GetOwinContext().Authentication;

            if (autentication != null && autentication.User != null && autentication.User.Identity != null)
            {
                var test = autentication.User.Identity as ApplicationUser;
                var g = new Guid();
                if (Guid.TryParse(autentication.User.Identity.GetUserId(), out g))
                {
                    result = g;
                }
            }

            return result;
        }        
	}
}