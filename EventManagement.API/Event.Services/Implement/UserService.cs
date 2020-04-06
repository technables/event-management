using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Services
{
    public class UserService : IUserService
    {
        public int Authenticate(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return 1;
            }
            return 0;
        }
    }
}
