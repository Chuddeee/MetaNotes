namespace MetaNotes.Models
{
    public class EditNoteModel
    {
        public int? NoteId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsPublic { get; set; }

        /// <summary>Может ли текущий пользователь редактировать заметку</summary>
        public bool CanEdit { get; set; }

        /// <summary>Может ли текущий пользователь удалить заметку</summary>
        public bool CanDelete { get; set; }
    }
}
