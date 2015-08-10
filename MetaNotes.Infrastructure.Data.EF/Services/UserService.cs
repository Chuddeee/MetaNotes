using MetaNotes.Common;
using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MetaNotes.Infrastructure.Data.EF
{
    internal class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow) { }

        public async Task<User> GetUser(Guid userId)
        {
            var repository = UnitOfWork.GetRepository<User>();

            return await repository.Select()
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();
        }

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
