namespace MetaNotes.Business.Services
{
    /// <summary>Аргументы для команды поиска пользователя по логину и паролю</summary>
    public class FindUserArgs : ICommandArguments
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
