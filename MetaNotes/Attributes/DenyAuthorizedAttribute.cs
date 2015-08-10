using MetaNotes.Common;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MetaNotes.Attributes
{
    /// <summary>Запрещает заходить залогиненному пользователю</summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class DenyAuthorizedAttribute : ActionFilterAttribute
    {
         private string RedirectUrl { get; set; }

        /// <summary>Конструктор</summary>
        /// <param name="redirectUrl">Урл, на который надо сделать редирект, 
        /// если пользователь залогинен</param>
         public DenyAuthorizedAttribute(string redirectUrl = UrlConstants.Notes)
         {
             RedirectUrl = redirectUrl.IsNullOrWhiteSpace() ? UrlConstants.Notes : redirectUrl;
         }

         public override void OnActionExecuting(ActionExecutingContext context)
         {
             var isAjaxRequest = context.RequestContext.HttpContext.Request.IsAjaxRequest();
             var user = HttpContext.Current.User;

             if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
             {
                 if (isAjaxRequest)
                 {
                     context.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                 }
                 else context.Result = new RedirectResult(RedirectUrl);
             }
         }
    }
}