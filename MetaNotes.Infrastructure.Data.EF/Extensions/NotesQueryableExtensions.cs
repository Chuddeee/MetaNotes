using MetaNotes.Core.Entities;
using MetaNotes.Extensions;
using System;
using System.Linq;

namespace MetaNotes.Infrastructure.Data.EF
{
    /// <summary>Методы расширения для IQueryable<Note></summary>
    internal static class NotesQueryableExtensions
    {
        /// <summary>Возвращает заметки создателя + публичные заметки</summary>
        internal static IQueryable<Note> FilterByOwnerId(this IQueryable<Note> query, Guid? userId)
        {
            if (userId.HasValue)
                return query.Where(x => x.OwnerId == userId || x.IsPublic);

            return query;
        }

        /// <summary>Фильтрует заметки по полю IsPublic</summary>
        internal static IQueryable<Note> FilterByIsPublic(this IQueryable<Note> query, bool? isPublic)
        {
            if (isPublic.HasValue)
                return query.Where(x => x.IsPublic == isPublic);

            return query;
        }

        /// <summary>Фильтрует заметки по ключевой фразе (в теле и в заголовке)</summary>
        internal static IQueryable<Note> FilterByKeyPhrase(this IQueryable<Note> query, string keyPhrase)
        {
            if (!keyPhrase.IsNullOrWhiteSpace())
            {
                var phrase = keyPhrase.ToLower();

                return query.Where(x =>
                    x.Body.ToLower().Contains(phrase) ||
                    x.Title.ToLower().Contains(phrase));
            }

            return query;
        }

        /// <summary>Отфильтровывает удаленные заметки</summary>
        internal static IQueryable<Note> NotDeleted(this IQueryable<Note> query)
        {
            return query.Where(x => !x.IsDeleted);
        }
    }
}
