﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaNotes.Models
{
    public class HeaderMenuModel
    {
        public IEnumerable<MenuItemModel> MenuItems { get; set; }
    }
}