using MetaNotes.Attributes;
using MetaNotes.Business.Services;
using MetaNotes.Infrastructure.Logger;
using MetaNotes.Models;
using MetaNotes.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Principal;
using MetaNotes.Common;
using MetaNotes.Core.Entities;

namespace MetaNotes.Controllers
{    
    [LogAction]
    public class AccountController : Controller
    {
        #region Поля, конструктор

        private readonly UserManager<ApplicationUser> _userManager = 
            new UserManager<ApplicationUser>(new UserStore());
        private readonly ICommand<FindUserArgs, FindUserResult> _findUserCommand;
        private readonly ILogger _logger;
        private readonly ILogReader _logReader;

        public AccountController(
            ICommand<FindUserArgs, FindUserResult> findUserCommand, 
            ILogger logger, ILogReader logReader)
        {
            _findUserCommand = findUserCommand;
            _logger = logger;
            _logReader = logReader;
        }

        #endregion



        [DenyAuthorized, HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(new SignInModel());
        }

        [DenyAuthorized, HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInModel request)
        {
            if (!ModelState.IsValid || request == null)
                return View("Index", request);

            var cmdResult = await _findUserCommand.Execute(new FindUserArgs
                {
                    Login = request.Login,
                    Password = request.Password
                });

            if (!cmdResult.IsSuccess)
            {
                ModelState.AddModelError("Password", cmdResult.ErrorMessage);
                return View("Index", request);
            }

            await SignIn(cmdResult.User);
            return RedirectToAction("Index", "Notes");
        }

        [Authorize, HttpGet]
        public async Task<ActionResult> SignOut()
        {
            var manager = HttpContext.GetOwinContext().Authentication;
            manager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Account");
        }

        private async Task SignIn(User user)
        {            
            var manager = HttpContext.GetOwinContext().Authentication;
            manager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            var identity = await _userManager.CreateIdentityAsync(
                new ApplicationUser
                {
                    UserName = user.Login,
                    Id = user.Id.ToString()
                },
                DefaultAuthenticationTypes.ApplicationCookie);

            Session[KeysConstants.UserSessionKey] = user;
            HttpContext.User = new GenericPrincipal(identity, new string[] { });
            manager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
        }
	}
}