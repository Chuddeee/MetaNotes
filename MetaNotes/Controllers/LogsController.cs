using MetaNotes.Common;
using MetaNotes.ModelBuilders;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetaNotes.Controllers
{
    [Authorize(Roles = RolesConstants.AdminRole)]
    public class LogsController : BaseController
    {
        /*
         К сожалению не хватило времени, чтобы нормально реализовать вывод логов.
         * Можно было бы сделать, чтобы можно было выбирать какой лог файл надо прочитать (из UI)
         * также организовать постраничный вывод в таблице, чтобы не весь лог файл сразу выводился, а определенное
         * количество лог сообщений, также так как лог сообщения парсятся, то можно было бы добавить фильтры по 
         * типу сообщения (Info, Error, ...), дате и т.д.
         */
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var builder = DependencyResolver.Current.GetService<LogsIndexModelBuilder>();
            var model = builder.Build(DateTime.Now);
            return View(model);
        }
    }
}