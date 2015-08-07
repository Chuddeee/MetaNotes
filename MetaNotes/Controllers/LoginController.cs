using MetaNotes.Attributes;
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
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [DenyAuthorized, HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(new SignInModel());
        }

        [DenyAuthorized, HttpPost]
        public async Task<ActionResult> SignIn(SignInModel request)
        {
            var manager = HttpContext.GetOwinContext().Authentication;
            manager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = await _userManager.CreateIdentityAsync(
                new ApplicationUser
                {
                    UserName = request.Login,
                    Id = Guid.NewGuid().ToString()
                },
                DefaultAuthenticationTypes.ApplicationCookie);

            manager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
            return View();
        }

        [Authorize, HttpPost]
        public async Task<ActionResult> SignOut()
        {
            return View();
        }
	}
}