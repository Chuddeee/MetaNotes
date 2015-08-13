using MetaNotes.Attributes;
using MetaNotes.Business.Services;
using MetaNotes.Common;
using MetaNotes.Internationalization.UI.Notes.Delete;
using MetaNotes.Internationalization.UI.Notes.Edit;
using MetaNotes.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    [Authorize]
    [LogAction]
    public class NotesController : BaseController
    {
        /*
         Примечание по поводу модел билдеров - можно было бы по аналогии с тем как реализовал команды
         * сделать generic интерфейс, определить интерфейс IViewModel и так далее, сигнатура
         * методов build сильно различается - где-то нужны параметры, где-то нет, где-то 
         * методы асинхронные, где-то нет, поэтому не стал усложнять. Как вариант можно было бы для
         * каждого билдера просто определить свой специфический интерфейс. В целом логика построения моделей
         * уже выделена в отдельные классы и при необходимости можно без проблем перевести все это дело на DI.
         * 
         * Также я бы создал фабрики для команд и билдеров, чтобы не надо было засорять конструктор контроллера
         * кучей зависимостей, а можно было бы инжектить только фабрики, которые бы могли создавать эти самые команды и 
         * билдеры.
         * 
         * По поводу ошибок можно было бы организовать единую схему работы с ошибками, выделить перечисления
         * с ошибками и менеджер ошибок (даже есть наработки), но к сожалению времени было мало и 
         * поднять полноценный проект я бы просто не успел
         * 
         * Также по причине нехватки времени пришлось использовать отправку через формы, а не ajax
         */

        [HttpGet]
        public async Task<ActionResult> Index(NotesFilterModel filter = null)
        {
            var builder = DependencyResolver.Current.GetService<NotesIndexModelBuilder>();
            var model = await builder.Build(GetUserId().Value, filter);
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
                    var model = await builder.Build(GetUserId().Value, noteId.Value);
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditNoteModel request)
        {
            if (!ModelState.IsValid)
            {
                request.CanEdit = true;
                return View(request);
            }

            var builder = DependencyResolver.Current.GetService<SaveNoteModelBuilder>();
            var result = await builder.Build(GetUserId().Value, request);

            if (result.IsSuccess)
            {
                TempData[KeysConstants.SuccessMessageKey] = NotesEditUIResources.NoteSuccessChanged;
                return RedirectToAction("Edit", new { noteId = request.NoteId.Value });
            }

            TempData[KeysConstants.ErrorMessageKey] = result.Error;
            return View(request);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int noteId)
        {
            var command = DependencyResolver.Current
                .GetService<ICommand<DeleteNoteArgs, EmptyCommandResult>>();

            var args = new DeleteNoteArgs
            {
                NoteId = noteId,
                UserId = GetUserId().Value
            };

            var result = await command.Execute(args);

            if (result.IsSuccess)
            {
                TempData[KeysConstants.SuccessMessageKey] = NotesDeleteUIResources.SuccessMsg;
                return RedirectToAction("Index", "Notes");
            }

            TempData[KeysConstants.ErrorMessageKey] = result.ErrorMessage;
            return RedirectToAction("Edit", "Notes", new { noteId = noteId });
        }
	}
}