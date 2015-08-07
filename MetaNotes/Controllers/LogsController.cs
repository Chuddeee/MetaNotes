using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    [Authorize]
    public class LogsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }
	}
}