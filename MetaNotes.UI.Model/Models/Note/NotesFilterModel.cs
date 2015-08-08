namespace MetaNotes.UI.Model
{
    /// <summary>Модель для фильтрации заметок</summary>
    public class NotesFilterModel
    {
        /// <summary>Тип заметок</summary>
        public NotesTypeFilter? Type { get; set; }

        /// <summary>Ключевая фраза</summary>
        public string KeyPhrase { get; set; }
    }

    /// <summary>Перечисление для фильтрации типов заметок</summary>
    public enum NotesTypeFilter
    {
        /// <summary>Все</summary>
        All = 0,

        /// <summary>Только мои (только заметки, которые создал пользователь)</summary>
        OnlyMy = 1,

        /// <summary>Только публичные заметки</summary>
        OnlyPublic = 2
    }
}
