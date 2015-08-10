using System;

namespace MetaNotes.Business.Services
{
    /// <summary>Аргументы для команды создания заметки</summary>
    public class CreateNoteArgs : ICommandArguments
    {
        /// <summary>Id пользователя, создающего заметку</summary>
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsPublic { get; set; }
    }
}
