using System;

namespace MetaNotes.Business.Services
{
    public class DeleteNoteArgs : ICommandArguments
    {
        public Guid UserId { get; set; }

        public int NoteId { get; set; }
    }
}
