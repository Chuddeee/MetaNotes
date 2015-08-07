using MetaNotes.Core.Entities;
using System;
using System.Collections.Generic;

namespace MetaNotes.Infrastructure.Data.EF
{
    /// <summary>Данные для предзаполнения таблицы Users</summary>
    internal static class UsersSeed
    {
        private const string _userLogin = "user";
        //123123
        private const string _defaultPassword = "4297F44B13955235245B2497399D7A93";

        internal static IEnumerable<User> GenerateUsers()
        {
            var result = new List<User>();

            for (int i = 1; i < 21; i++)
            {
                result.Add(new User
                {
                    Id = Guid.NewGuid(),
                    IsAdmin = i % 2 == 0,
                    Login = _userLogin + i,
                    Password = _defaultPassword,
                    UserNotes = new List<Note>()
                });
            }

            return result;
        }
    }
}
