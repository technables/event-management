﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entity
{
    public class AuthInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }

    public class UserInfo : AuthInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
    }

    
}
