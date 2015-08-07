using MetaNotes.Business.Services;
using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public async Task<User> GetUser(string login, string passwordHash)
        {
            var repository = UnitOfWork.GetRepository<User>();

            return await repository.Select()
                .Where(x => x.Login == login && x.Password == passwordHash)
                .FirstOrDefaultAsync();
        }
    }
}
