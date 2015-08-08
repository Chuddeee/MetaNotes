using MetaNotes.Core.Entities;
using System;
using System.Collections.Generic;

namespace MetaNotes.Infrastructure.Data.EF
{
    internal static class NotesSeed
    {
        private const string _defaultTitle = "Дефолтный заголовок";
        private const string _defaultBody = "Дефолтное тело заметки";

        internal static IEnumerable<Note> GenerateNotes()
        {
            var result = new List<Note>();

            var utc = DateTime.UtcNow;

            for (int i = 0; i < 100; i++)
            {
                result.Add(new Note()
                {
                    CreatingDate = utc.AddMinutes(-i),
                    Body = _defaultBody,
                    Title = _defaultTitle,
                    IsPublic = i % 2 == 0
                });
            }

            return result;
        }
    }
}
