using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MetaNotes.UI.Model
{
    public class NotesIndexModel : IViewModel
    {
        //При переименовывании названия параметра также возможно надо будет 
        //переименовать название переменной в контроллере
        public NotesFilterModel Filter { get; set; }

        /// <summary>Набор данных для таблички</summary>
        public IQueryable<NoteTableModel> Data { get; set; }

        /// <summary>Является ли текущий пользователь админом</summary>
        public bool IsAdmin { get; set; }

        /// <summary>Значения для комбобокса типа записей</summary>
        public IEnumerable<SelectListItem> PublicDropDownList { get; set; }
    }
}
