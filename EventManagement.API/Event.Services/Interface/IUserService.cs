using Event.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Services
{
    public interface IUserService
    {
        public UserInfo Authenticate(string username, string password);
    }
}
