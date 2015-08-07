namespace MetaNotes.Business.Services
{
    /// <summary>Аргументы для команды поиска пользователя</summary>
    public class FindUserArgs : ICommandArguments
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
