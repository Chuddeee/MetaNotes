using Microsoft.AspNet.Identity;

namespace MetaNotes.Infrastructure.Authentication
{
    public class UserManager : UserManager<ApplicationUser>
    {
        private readonly IUserStore<ApplicationUser> _store;

        public UserManager(IUserStore<ApplicationUser> userStore)
            : base(userStore)
        {
            _store = userStore;
        }
    }
}
