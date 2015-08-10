using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using MetaNotes.Internationalization.Errors.Note;
using MetaNotes.Internationalization.Errors.System;
using MetaNotes.Internationalization.Errors.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Business.Services
{
    internal class DeleteNoteCommand : BaseCommand<DeleteNoteArgs, EmptyCommandResult>
    {
        #region Поля, конструктор

        private readonly IUserService _userService;
        private readonly INoteService _noteService;
        private User _user;
        private Note _note;

        public DeleteNoteCommand(IUnitOfWork uow, IUserService userService, INoteService notesService)
            : base(uow)
        {
            _userService = userService;
            _noteService = notesService;
        }

        #endregion



        protected override async Task<EmptyCommandResult> PerformCommand(DeleteNoteArgs arguments)
        {
            var result = new EmptyCommandResult() { IsSuccess = true };
            _note.IsDeleted = true;
            _note.DeletingDate = DateTime.UtcNow;
            
            var repository = UnitOfWork.GetRepository<Note>();
            repository.Update(_note);
            await UnitOfWork.SaveChangesAsync();

            return result;
        }



        protected override async Task<EmptyCommandResult> Validate(DeleteNoteArgs arguments)
        {
            var result = new EmptyCommandResult() { IsSuccess = true };

            if (arguments == null)
            {
                result.AddError(SystemErrors.InvalidRequest);
                return result;
            }

            var userTask = _userService.GetUser(arguments.UserId);
            var noteTask = _noteService.GetNote(arguments.NoteId);

            await Task.WhenAll(userTask, noteTask);

            _user = userTask.Result;
            _note = noteTask.Result;

            if (_user == null)
            {
                result.AddError(UserErrors.UserNotFound);
                return result;
            }

            if (_note == null)
            {
                result.AddError(NoteErrors.NoteNotFound);
                return result;
            }

            if (!_note.CanDelete(_user))
            {
                result.AddError(UserErrors.UserCannotDeleteNote);
                return result;
            }

            return result;
        }
    }
}
