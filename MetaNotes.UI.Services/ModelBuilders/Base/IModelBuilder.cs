using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekleft.VendingMachine.UI.Model;

namespace Ekleft.VendingMachine.UI.Services
{
    /// <summary>Интерфейс модел билдера</summary>
    /// <typeparam name="TModel">Тип модели, который билдер должен построить</typeparam>
    /// <typeparam name="TArguments">Тип входных параметров</typeparam>
    public interface IModelBuilder<TModel, TArguments>
        where TModel : IViewModel
        where TArguments : IModelBuilderArguments
    {
        /// <summary>Строит модель</summary>
        Task<TModel> Build(TArguments arguments);
    }
}
