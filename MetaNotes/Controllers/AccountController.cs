using MetaNotes.Attributes;
using MetaNotes.Business.Services;
using MetaNotes.UI.Model;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{    
    public class AccountController : Controller
    {
        #region Поля, конструктор

        private readonly UserManager<ApplicationUser> _userManager = 
            new UserManager<ApplicationUser>(new UserStore());
        private readonly ICommand<FindUserArgs, FindUserResult> _findUserCommand;

        public AccountController(ICommand<FindUserArgs, FindUserResult> findUserCommand)
        {
            _findUserCommand = findUserCommand;
        }

        #endregion



        [DenyAuthorized, HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(new SignInModel());
        }

        [DenyAuthorized, HttpPost]
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

            await SignIn(cmdResult.User.Login, cmdResult.User.Id);
            return RedirectToAction("Index", "Notes");
        }

        [Authorize, HttpGet]
        public async Task<ActionResult> SignOut()
        {
            var manager = HttpContext.GetOwinContext().Authentication;
            manager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Account");
        }

        private async Task SignIn(string login, Guid userId)
        {            
            var manager = HttpContext.GetOwinContext().Authentication;
            manager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            var identity = await _userManager.CreateIdentityAsync(
                new ApplicationUser
                {
                    UserName = login,
                    Id = userId.ToString()
                },
                DefaultAuthenticationTypes.ApplicationCookie);

            manager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
        }
	}
}