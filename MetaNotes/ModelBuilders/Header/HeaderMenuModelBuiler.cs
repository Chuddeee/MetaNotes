using MetaNotes.Internationalization.UI.Layout;
using MetaNotes.Models;
using System;
using System.Collections.Generic;

namespace MetaNotes.ModelBuilders
{
    public class HeaderMenuModelBuiler
    {
        public HeaderMenuModel Build(Guid? userId, bool isAdmin)
        {
            var items = new List<MenuItemModel>();
            var result = new HeaderMenuModel() { MenuItems = items };

            if (!userId.HasValue)
                return result;

           items.Add(CreateItem("Index", "Notes",MainLayoutResources.Notes_Menu));

            if(isAdmin)
            {
                items.Add(CreateItem("Index", "Logs", MainLayoutResources.Logs_Menu));
            }

            items.Add(CreateItem("Signout", "Account", MainLayoutResources.SignOut_Menu));

            return result;
        }

        private MenuItemModel CreateItem(string action, string controller, string name)
        {
            return new MenuItemModel
            {
                ActionName = action,
                ControllerName = controller,
                Name = name
            };
        }
    }
}