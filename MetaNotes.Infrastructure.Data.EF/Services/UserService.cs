using MetaNotes.Business.Services;
using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using MetaNotes.Extensions;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MetaNotes.Infrastructure.Data.EF
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow) { }

        public async Task<User> GetUser(Guid userId)
        {
            var repository = UnitOfWork.GetRepository<User>();

            return await repository.Select()
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();
        }

        /// <summary>Получает пользователя по логину и паролю. </summary>
        /// <param name="login">логин пользователя</param>
        /// <param name="passwordHash">хеш код пароля</param>
        public async Task<User> GetUser(string login, string passwordHash)
        {
            if (login.IsNullOrWhiteSpace() || passwordHash.IsNullOrWhiteSpace())
                return null;

            var lowerLogin = login.ToLower();
            var repository = UnitOfWork.GetRepository<User>();

            return await repository.Select()
                .AsNoTracking()
                .Where(x => x.Login.ToLower() == lowerLogin && x.Password == passwordHash)
                .FirstOrDefaultAsync();
        }
    }
}
