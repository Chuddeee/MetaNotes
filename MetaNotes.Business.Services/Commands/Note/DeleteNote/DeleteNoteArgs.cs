using System;

namespace MetaNotes.Business.Services
{
    /// <summary>Аргументы команды удаления заметки</summary>
    public class DeleteNoteArgs : ICommandArguments
    {
        /// <summary>Id пользователя, который удаляет заметку</summary>
        public Guid UserId { get; set; }

        public int NoteId { get; set; }
    }
}
