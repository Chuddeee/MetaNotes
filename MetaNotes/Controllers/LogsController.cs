using MetaNotes.ModelBuilders;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    [Authorize]
    public class LogsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var builder = DependencyResolver.Current.GetService<LogsIndexModelBuilder>();
            var model = builder.Build(DateTime.Now);
            return View(model);
        }
	}
}