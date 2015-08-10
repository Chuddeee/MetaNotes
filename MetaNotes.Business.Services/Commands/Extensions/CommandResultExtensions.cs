namespace MetaNotes.Business.Services
{
    /// <summary>Расширения для результатов команд</summary>
    internal static class CommandResultExtensions
    {
        public static TResult AddError<TResult>(this TResult result, string error)
            where TResult : ICommandResult
        {
            if (result == null)
                return result;

            result.ErrorMessage = error;
            result.IsSuccess = false;
            return result;
        }
    }
}
