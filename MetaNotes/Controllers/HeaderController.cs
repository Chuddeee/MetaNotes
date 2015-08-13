using MetaNotes.Common;
using MetaNotes.ModelBuilders;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    public class HeaderController : BaseController
    {
        public PartialViewResult Menu()
        {
            var builder = new HeaderMenuModelBuiler();
            var model = builder.Build(GetUserId(), UserIsInRole(RolesConstants.AdminRole));
            return PartialView("~/Views/Header/HeaderPartial.cshtml", model);
        }
	}
}