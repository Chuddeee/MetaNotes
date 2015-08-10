using System;

namespace MetaNotes.Business.Services
{
    /// <summary>Команда изменения заметки</summary>
    public class EditNoteArgs : ICommandArguments
    {
        /// <summary>Id пользователя, который изменяет заметку</summary>
        public Guid ChangedByUserId { get; set; }

        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsPublic { get; set; }
    }
}
