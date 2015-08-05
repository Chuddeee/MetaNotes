namespace MetaNotes.Business.Services
{
    /// <summary>Результат выполнения команды</summary>
    public interface ICommandResult
    {
        /// <summary>True, если команда завешилась успешно, иначе false</summary>
        bool IsSuccess { get; set; }

        string ErrorMessage { get; set; }
    }
}
