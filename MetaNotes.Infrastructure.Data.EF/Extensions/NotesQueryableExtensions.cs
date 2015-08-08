using MetaNotes.Core.Entities;
using MetaNotes.Extensions;
using System;
using System.Linq;

namespace MetaNotes.Infrastructure.Data.EF
{
    internal static class NotesQueryableExtensions
    {
        /// <summary>Фильтрует заметки по id создателя + публичные заметки</summary>
        internal static IQueryable<Note> FilterByOwnerId(this IQueryable<Note> query, Guid? userId)
        {
            if (userId.HasValue)
                return query.Where(x => x.OwnerId == userId || x.IsPublic);

            return query;
        }

        internal static IQueryable<Note> FilterByIsPublic(this IQueryable<Note> query, bool? isPublic)
        {
            if (isPublic.HasValue)
                return query.Where(x => x.IsPublic == isPublic);

            return query;
        }

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

        internal static IQueryable<Note> NotDeleted(this IQueryable<Note> query)
        {
            return query.Where(x => !x.IsDeleted);
        }
    }
}
