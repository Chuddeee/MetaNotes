using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaNotes.Models
{
    /// <summary>Модель для отображения пунктов меню</summary>
    public class MenuItemModel
    {
        /// <summary>Текст пункта меню</summary>
        public string Name { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        /// <summary>css класс, который надо применить к пункту меню</summary>
        public string ClassName { get; set; }

        public bool IsActive { get; set; }
    }
}