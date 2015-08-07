using MetaNotes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Business.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Guid userId);

        Task<User> GetUser(string login, string passwordHash);
    }
}
