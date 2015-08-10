using MetaNotes.Business.Services;

namespace MetaNotes.Business.Services
{
    public class CreateNoteResult : BaseCommandResult
    {
        public int CreatedNoteId { get; set; }
    }
}
