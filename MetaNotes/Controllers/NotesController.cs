using MetaNotes.UI.Model;
using MetaNotes.UI.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web;
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
            if (noteId.HasValue)
            {
                var builder = DependencyResolver.Current.GetService<EditNoteModelBuilder>();

                try
                {
                    var model = await builder.Build(UserId.Value, noteId.Value);
                    return View(model);
                }
                catch (ModelBuilderException ex)
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "");
                }
            }

            return View(new EditNoteModel
                {
                    CanEdit = true,
                });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditNoteModel request)
        {
            if(request == null)
                return View(request);



            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int noteId)
        {
            return View();
        }
	}
}