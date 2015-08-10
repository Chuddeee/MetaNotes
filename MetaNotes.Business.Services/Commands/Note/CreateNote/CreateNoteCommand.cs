using MetaNotes.Core.Entities;
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
    public class CreateNoteCommand : BaseCommand<CreateNoteArgs, CreateNoteResult>
    {
        #region Поля, конструктор

        private readonly IUserService _userService;
        private readonly INoteService _noteService;
        private User _user;

        public CreateNoteCommand(IUnitOfWork uow, IUserService userService, INoteService notesService)
            : base(uow)
        {
            _userService = userService;
            _noteService = notesService;
        }

        #endregion


        protected override async Task<CreateNoteResult> PerformCommand(CreateNoteArgs arguments)
        {
            var result = new CreateNoteResult() { IsSuccess = true };

            var note = new Note
            {
                OwnerId = arguments.UserId,
                Title = arguments.Title,
                Body = arguments.Body,
                CreatingDate = DateTime.UtcNow,
                IsPublic = arguments.IsPublic
            };

            var repository = UnitOfWork.GetRepository<Note>();
            repository.Add(note);
            await UnitOfWork.SaveChangesAsync();

            return result;
        }

        protected override async Task<CreateNoteResult> Validate(CreateNoteArgs arguments)
        {
            var result = new CreateNoteResult() { IsSuccess = true };

            if(arguments == null)
            {
                result.AddError(SystemErrors.InvalidRequest);
                return result;
            }

            _user = await _userService.GetUser(arguments.UserId);

            if(_user == null)
            {
                result.AddError(UserErrors.UserNotFound);
                return result;
            }           
           
            return result;
        }
    }
}
