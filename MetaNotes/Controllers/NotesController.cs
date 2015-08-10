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

            if(request.NoteId.HasValue)
            {
                var editCommand = DependencyResolver.Current
                    .GetService<ICommand<EditNoteArgs, EmptyCommandResult>>();

                var args = new EditNoteArgs
                {
                    Body = request.Body,
                    ChangedByUserId = UserId.Value,
                    IsPublic = request.IsPublic,
                    NoteId = request.NoteId.Value,
                    Title = request.Title
                };

                var result = await editCommand.Execute(args);

                if(result.IsSuccess)
                {
                    TempData[KeysConstants.SuccessMessageKey] = NotesEditUIResources.NoteSuccessChanged;
                    return RedirectToAction("Edit", new { noteId = request.NoteId.Value });
                }
                else
                {
                    TempData[KeysConstants.ErrorMessageKey] = result.ErrorMessage;
                    return View(request);
                }
            }

            var createCommand = DependencyResolver.Current
                  .GetService<ICommand<CreateNoteArgs, EmptyCommandResult>>();

            var createArgs = new CreateNoteArgs
            {
                Body = request.Body,
                IsPublic = request.IsPublic,
                Title = request.Title,
                UserId = UserId.Value
            };

            var createResult = await createCommand.Execute(createArgs);

            if (createResult.IsSuccess)
            {
                TempData[KeysConstants.SuccessMessageKey] = NotesEditUIResources.NoteSuccessCreated;
                return RedirectToAction("Edit", new { noteId = request.NoteId.Value });
            }
            else
            {
                TempData[KeysConstants.ErrorMessageKey] = createResult.ErrorMessage;
                return View(request);
            }
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
            else
            {
                TempData[KeysConstants.ErrorMessageKey] = result.ErrorMessage;
            }

            return RedirectToAction("Index");
        }
	}
}