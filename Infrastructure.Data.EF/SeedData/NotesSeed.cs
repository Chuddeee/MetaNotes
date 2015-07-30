using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF.SeedData
{
    internal static class NotesSeed
    {
        private const string _defaultTitle = "Дефолтный заголовок";
        private const string _defaultBody = "Дефолтное тело заметки";

        internal static IEnumerable<Note> GenerateNotes()
        {
            var result = new List<Note>();

            for (int i = 0; i < 100; i++)
            {
                var creatingDate = DateTime.UtcNow;

                var note = new Note()
                {
                    CreatingDate = creatingDate.AddMinutes(-i),        
                    Body = _defaultBody,
                    Title = _defaultTitle
                };
            }

            return result;
        }
    }
}
