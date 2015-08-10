using MetaNotes.Business.Services;
using MetaNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MetaNotes
{
    /// <summary>Модел билдер для сохранения заметки (обновления или создания)</summary>
    public class SaveNoteModelBuilder
    {
        private readonly ICommand<EditNoteArgs, EmptyCommandResult> _editCommand;
        private readonly ICommand<CreateNoteArgs, CreateNoteResult> _createCommand;

        public SaveNoteModelBuilder(ICommand<EditNoteArgs, EmptyCommandResult> editCommand,
            ICommand<CreateNoteArgs, CreateNoteResult> createCommand)
        {
            _editCommand = editCommand;
            _createCommand = createCommand;
        }


        public async Task<SaveNoteModelBuilderResult> Build(Guid userId, EditNoteModel request)
        {
            var result = new SaveNoteModelBuilderResult()
            {
                Model = request,
                IsSuccess = true
            };

            if (request == null)
                return result;

            if (request.NoteId.HasValue)
            {
                return await ExecuteEditCmd(userId, request, result);
            }
            else return await ExecuteCreateCmd(userId, request, result);
          
        }

        private async Task<SaveNoteModelBuilderResult> ExecuteEditCmd(Guid userId,
            EditNoteModel request, SaveNoteModelBuilderResult result)
        {
            var args = new EditNoteArgs
            {
                Body = request.Body,
                ChangedByUserId = userId,
                IsPublic = request.IsPublic,
                NoteId = request.NoteId.Value,
                Title = request.Title
            };

            var cmdRes = await _editCommand.Execute(args);

            if (!cmdRes.IsSuccess)
            {
                result.IsSuccess = false;
                result.Error = cmdRes.ErrorMessage;
                return result;
            }
            else return result;
        }

        private async Task<SaveNoteModelBuilderResult> ExecuteCreateCmd(Guid userId,
            EditNoteModel request, SaveNoteModelBuilderResult result)
        {
            var createArgs = new CreateNoteArgs
            {
                Body = request.Body,
                IsPublic = request.IsPublic,
                Title = request.Title,
                UserId = userId
            };

            var createResult = await _createCommand.Execute(createArgs);

            if (!createResult.IsSuccess)
            {
                result.IsSuccess = false;
                result.Error = createResult.ErrorMessage;
                return result;
            }

            result.Model.NoteId = createResult.CreatedNoteId;
            return result;
        }
    }
}