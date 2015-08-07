using MetaNotes.UI.Model;
using System.Threading.Tasks;

namespace MetaNotes.UI.Services
{
    /// <summary>Интерфейс строителя моделей</summary>
    /// <typeparam name="TModel">Тип модели, который билдер должен построить</typeparam>
    /// <typeparam name="TArguments">Тип входных параметров</typeparam>
    public interface IModelBuilder<TModel, TArguments>
        where TModel : IViewModel
    {
        /// <summary>Строит модель</summary>
        Task<TModel> Build(TArguments arguments);
    }
}
