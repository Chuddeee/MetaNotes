using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace MetaNotes
{
    public class UserStore : IUserStore<ApplicationUser>
    {
        public Task CreateAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }
       

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
