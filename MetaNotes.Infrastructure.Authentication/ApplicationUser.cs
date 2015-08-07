﻿using Microsoft.AspNet.Identity;

namespace MetaNotes.Infrastructure.Authentication
{
    public class ApplicationUser : IUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
