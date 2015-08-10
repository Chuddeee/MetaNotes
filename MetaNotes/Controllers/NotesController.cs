using MetaNotes.Business.Services;
using MetaNotes.Common;
using MetaNotes.Internationalization.UI.Notes.Edit;
using MetaNotes.Models;
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
            var a = ModelState;
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
            var builder = DependencyResolver.Current.GetService<SaveNoteModelBuilder>();
            var result = await builder.Build(UserId.Value, request);

            if (result.IsSuccess)
            {
                TempData[KeysConstants.SuccessMessageKey] = NotesEditUIResources.NoteSuccessChanged;
                return RedirectToAction("Edit", new { noteId = request.NoteId.Value });
            }

            TempData[KeysConstants.ErrorMessageKey] = result.Error;
            return View(request);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int noteId)
        {
            var command = DependencyResolver.Current
                .GetService<ICommand<DeleteNoteArgs, EmptyCommandResult>>();

            var args = new DeleteNoteArgs
            {
                NoteId = noteId,
                UserId = UserId.Value
            };

            var result = await command.Execute(args);

            if (result.IsSuccess)
            {
                TempData[KeysConstants.SuccessMessageKey] = NotesEditUIResources.NoteSuccessDeleted;
            }
            else TempData[KeysConstants.ErrorMessageKey] = result.ErrorMessage;

            return RedirectToAction("Index");
        }
	}
}