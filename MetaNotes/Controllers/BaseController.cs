using MetaNotes.Common;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>Получает Id текущего юзера</summary>
        protected Guid? GetUserId()
        {
            Guid? result = null;
            var claimsPrincipal = GetClaimsPrincipal();

            if (claimsPrincipal != null)
            {
                var idClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
                var value = idClaim.Maybe(x => x.Value);

                Guid g;
                if (!value.IsNullOrWhiteSpace() && Guid.TryParse(value, out g))
                {
                    result = g;
                }
            }

            return result;
        }        

        /// <summary>Проверяет есть ли у пользователя роль</summary>
        protected bool UserIsInRole(string role)
        {
            bool result = false;
            var claimsPrincipal = GetClaimsPrincipal();

            if (claimsPrincipal != null)
            {
                result = claimsPrincipal.IsInRole(role);
            }

            return result;
        }

        private ClaimsPrincipal GetClaimsPrincipal()
        {
            return HttpContext
                .Maybe(x => x.GetOwinContext())
                .Maybe(x => x.Authentication)
                .Maybe(x => x.User);
        }
	}
}