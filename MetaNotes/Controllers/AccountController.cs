using MetaNotes.Attributes;
using MetaNotes.Business.Services;
using MetaNotes.Common;
using MetaNotes.Core.Entities;
using MetaNotes.Models;
using MetaNotes.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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

        public AccountController(ICommand<FindUserArgs, FindUserResult> findUserCommand,
            ILogger logger)
        {
            _findUserCommand = findUserCommand;
            _logger = logger;
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
            var identity = _userManager.CreateIdentity(new ApplicationUser
                {
                    Id = user.Id.ToString(),
                    UserName = user.Login
                }, DefaultAuthenticationTypes.ApplicationCookie);

            if (user.IsAdmin)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, RolesConstants.AdminRole));
            }

            var manager = HttpContext.GetOwinContext().Authentication;
            manager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            manager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
        }
	}
}