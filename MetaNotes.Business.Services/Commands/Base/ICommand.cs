using System.Threading.Tasks;

namespace MetaNotes.Business.Services
{
    /// <summary>Команда, выполняющая какие-либо действия</summary>
    /// <typeparam name="TArguments">Тип входных аргументов для команды</typeparam>
    public interface ICommand<TArguments, TResult>
        where TArguments : ICommandArguments
        where TResult : ICommandResult
    {
        Task<TResult> Execute(TArguments arguments);
    }
}
