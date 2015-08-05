using MetaNotes.UI.Model;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    public class NotesController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
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