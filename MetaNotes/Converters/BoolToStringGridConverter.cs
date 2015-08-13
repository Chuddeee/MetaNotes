using MetaNotes.Internationalization.UI.Notes.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaNotes.Converters
{
    /// <summary>Класс, который занимается преобразованием булевой переменной
    /// в строковое представление для отображения в таблице</summary>
    public class BoolToStringGridConverter
    {
        public static string GetStr(bool value)
        {
            return value ?
                NotesIndexUIResources.PublicText_grid :
                NotesIndexUIResources.NotPublicText_grid1;
        }
    }
}