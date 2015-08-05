using MetaNotes.UI.Model;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet] 
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInModel request)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignOut()
        {
            return View();
        }
	}
}