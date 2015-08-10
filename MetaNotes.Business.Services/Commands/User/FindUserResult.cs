using MetaNotes.Core.Entities;

namespace MetaNotes.Business.Services
{
    /// <summary>Результат команды поиска пользователя по логину паролю</summary>
    public class FindUserResult : BaseCommandResult
    {
        public User User { get; set; }
    }
}
