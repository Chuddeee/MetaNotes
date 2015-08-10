using MetaNotes.Core.Entities;
using System;
using System.Threading.Tasks;

namespace MetaNotes.Core.Services
{
    /// <summary>Сервис для работы с пользователем</summary>
    public interface IUserService
    {
        /// <summary>Возвращает пользователя или null, если он не найден</summary>
        Task<User> GetUser(Guid userId);

        /// <summary>Возвращает пользователя по логину и паролю или null, если он не найден</summary>
        /// <param name="login">логин пользователя</param>
        /// <param name="passwordHash">хеш код пароля пользователя</param>
        Task<User> GetUser(string login, string passwordHash);
    }
}
