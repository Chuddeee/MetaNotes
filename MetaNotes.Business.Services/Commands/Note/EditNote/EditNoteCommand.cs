using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using MetaNotes.Internationalization.Errors.Note;
using MetaNotes.Internationalization.Errors.System;
using MetaNotes.Internationalization.Errors.User;
using System;
using System.Threading.Tasks;

namespace MetaNotes.Business.Services
{
    internal class EditNoteCommand : BaseCommand<EditNoteArgs, EmptyCommandResult>
    {
        #region Поля, конструктор

        private readonly IUserService _userService;
        private readonly INoteService _noteService;
        private User _user;
        private Note _note;

        public EditNoteCommand(IUnitOfWork uow, IUserService userService, INoteService notesService)
            : base(uow)
        {
            _userService = userService;
            _noteService = notesService;
        }

        #endregion


        protected override async Task<EmptyCommandResult> PerformCommand(EditNoteArgs arguments)
        {
            var result = new EmptyCommandResult() { IsSuccess = true };

            _note.Body = arguments.Body;
            _note.Title = arguments.Title;
            _note.IsPublic = arguments.IsPublic;
            _note.ChangedByUserId = arguments.ChangedByUserId;
            _note.ChangingDate = DateTime.UtcNow;

            var repository = UnitOfWork.GetRepository<Note>();
            repository.Update(_note);
            await UnitOfWork.SaveChangesAsync();

            return result;
        }

        protected override async Task<EmptyCommandResult> Validate(EditNoteArgs arguments)
        {
            var result = new EmptyCommandResult() { IsSuccess = true };

            if(arguments == null)
            {
                result.AddError(SystemErrors.InvalidRequest);
                return result;
            }

            var userTask = _userService.GetUser(arguments.ChangedByUserId);
            var noteTask = _noteService.GetNote(arguments.NoteId);

            await Task.WhenAll(userTask, noteTask);

            _user = userTask.Result;
            _note = noteTask.Result;

            if(_user == null)
            {
                result.AddError(UserErrors.UserNotFound);
                return result;
            }

            if(_note == null)
            {
                result.AddError(NoteErrors.NoteNotFound);
                return result;
            }

            if(!_note.CanEdit(_user))
            {
                result.AddError(UserErrors.UserCannotEditNote);
                return result;
            }

            return result;
        }
    }
}
