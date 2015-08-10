using System;

namespace MetaNotes.UI.Model
{
    /// <summary>Модель для отображения заметки в таблице</summary>
    public class NoteTableModel : IViewModel
    {
        /// <summary>Id записи</summary>
        public int Id { get; set; }

        /// <summary>Заголовок записи</summary>
        public string Title { get; set; }

        /// <summary>Id пользователя, который создал запись</summary>
        public Guid UserId { get;set; }

        /// <summary>Является ли запись публичной</summary>
        public bool IsPublic { get; set; }

        /// <summary>Дата создания записи</summary>
        public DateTime CreatingDate { get; set; }
    }
}
