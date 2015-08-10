using MetaNotes.Common;
using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using MetaNotes.Internationalization.Errors.System;
using MetaNotes.Internationalization.Errors.User;
using System.Threading.Tasks;

namespace MetaNotes.Business.Services
{
    /// <summary>Команда поиска пользователя по логину и паролю</summary>
    internal class FindUserCommand : BaseCommand<FindUserArgs, FindUserResult>
    {
        private readonly IUserService _userService;
        private readonly ICryptographyUtility _crypto;
        private User _user;

        public FindUserCommand(IUnitOfWork uow, IUserService userService, ICryptographyUtility crypto) : base(uow)
        {
            _userService = userService;
            _crypto = crypto;
        }

        protected override async Task<FindUserResult> PerformCommand(FindUserArgs arguments)
        {
            var result = new FindUserResult() 
            { 
                IsSuccess = true,
                User = _user
            };

            return result;
        }

        protected override async Task<FindUserResult> Validate(FindUserArgs arguments)
        {
            var result = new FindUserResult() { IsSuccess = true };

            if (arguments == null ||
                arguments.Login.IsNullOrWhiteSpace() ||
                arguments.Password.IsNullOrWhiteSpace())
            {
                result.AddError(SystemErrors.InvalidRequest);
                return result;
            }

            var hash = _crypto.GetHash(arguments.Password);
            _user = await _userService.GetUser(arguments.Login, hash);

            if (_user == null)
            {
                result.AddError(UserErrors.InvalidLoginOrPassword);
                return result;
            }

            return result;
        }
    }
}
