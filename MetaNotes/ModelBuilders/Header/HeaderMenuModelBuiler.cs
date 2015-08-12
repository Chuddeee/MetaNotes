using MetaNotes.Models.Header;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace MetaNotes.ModelBuilders.Header
{
    public class HeaderMenuModelBuiler
    {
        public async Task<HeaderMenuModel> Build(Guid? userId)
        {
            var result = new HeaderMenuModel()
            {
                MenuItems = new List<MenuItemModel>()
            };

            if (!userId.HasValue)
                return result;

            //HttpContext.Current.User.isi
            return null;
        }
    }
}