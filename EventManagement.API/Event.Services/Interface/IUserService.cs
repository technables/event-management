using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Services
{
    public interface IUserService
    {
        public int Authenticate(string username, string password);
    }
}
