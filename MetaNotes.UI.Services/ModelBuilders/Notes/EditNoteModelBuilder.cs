using MetaNotes.Business.Services;
using MetaNotes.Core.Services;
using MetaNotes.UI.Model;
using System;
using System.Threading.Tasks;

namespace MetaNotes.UI.Services
{
    public class EditNoteModelBuilder
    {
        private readonly INoteService _notesService;
        private readonly IUserService _userService;

        public EditNoteModelBuilder(INoteService notesService, IUserService userService)
        {
            _notesService = notesService;
            _userService = userService;
        }

        public async Task<EditNoteModel> Build(Guid userId, int noteId)
        {
            var userTask = _userService.GetUser(userId);
            var noteTask = _notesService.GetNote(noteId);

            await Task.WhenAll(userTask, noteTask);

            var user = userTask.Result;
            var note = noteTask.Result;

            if (user == null)
                throw new ModelBuilderException("user not found");

            if (note == null || !note.CanSee(user))
                throw new ModelBuilderException("note not found");

            var canEdit = note.CanEdit(user);
            var canDelete = note.CanDelete(user);

            var model = new EditNoteModel()
            {
                Body = note.Body,
                IsPublic = note.IsPublic,
                Title = note.Title,
                NoteId = noteId,
                CanEdit = canEdit,
                CanDelete = canDelete
            };

            return model;
        }
    }
}
