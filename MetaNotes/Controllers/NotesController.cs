using MetaNotes.UI.Model;
using MetaNotes.UI.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    [Authorize]
    public class NotesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index(NotesFilterModel filter = null)
        {
            var builder = DependencyResolver.Current.GetService<NotesIndexModelBuilder>();
            var model = await builder.Build(UserId.Value, filter);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? noteId)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditNoteModel request)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int noteId)
        {
            return View();
        }
	}
}