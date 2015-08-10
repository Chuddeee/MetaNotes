using MetaNotes.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MetaNotes.Core.Services
{
    /// <summary>Сервис для работы с заметками</summary>
    public interface INoteService
    {
        /// <summary>Возвращает отфильтрованные записи</summary>
        /// <param name="isPublic">является ли публичным. Если надо вернуть все, то null</param>
        /// <param name="keyPhrase">ключевая фраза</param>
        /// <param name="userId">id пользователя создателя записей</param>
        IQueryable<Note> GetFilteredNotes(Guid? userId, bool? isPublic, string keyPhrase);

        /// <summary>Возвращает заметку или null, если она не была найдена</summary>
        /// <param name="id">id заметки</param>
        Task<Note> GetNote(int id);
    }
}
