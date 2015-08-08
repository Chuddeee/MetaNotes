using MetaNotes.Core.Entities;
using System;
using System.Linq;

namespace MetaNotes.Business.Services
{
    public interface INotesService
    {
        /// <summary>Фильтрует записи</summary>
        /// <param name="isPublic">является ли публичным. Если надо вернуть все, то null</param>
        /// <param name="keyPhrase">ключевая фраза</param>
        /// <param name="userId">id пользователя создателя записей</param>
        IQueryable<Note> GetFilteredNotes(Guid? userId, bool? isPublic, string keyPhrase);
    }
}
