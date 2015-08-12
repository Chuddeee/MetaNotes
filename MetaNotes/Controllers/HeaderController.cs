using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    public class HeaderController : BaseController
    {
        public PartialViewResult Menu()
        {
           
            return PartialView("~/Views/Shared/Partial/Header/ParentHeader.cshtml", null);
        }
	}
}