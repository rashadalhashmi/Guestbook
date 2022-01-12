﻿using Microsoft.AspNetCore.Identity;

namespace Guestbook.Data
{
    public class ApplicationUserEntity: IdentityUser
    {
        public string UserName { get; set; }

    }
}