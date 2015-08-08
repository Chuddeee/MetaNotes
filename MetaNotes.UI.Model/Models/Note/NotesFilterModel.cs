namespace MetaNotes.UI.Model
{
    /// <summary>Модель для фильтрации заметок</summary>
    public class NotesFilterModel
    {
        /// <summary>Является ли публичным</summary>
        public bool? IsPublic { get; set; }

        /// <summary>Ключевая фраза</summary>
        public string KeyPhrase { get; set; }
    }
}
