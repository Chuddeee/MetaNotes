using System;

namespace MetaNotes.Business.Services
{
    public class EditNoteArgs : ICommandArguments
    {
        public Guid ChangedByUserId { get; set; }

        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsPublic { get; set; }
    }
}
