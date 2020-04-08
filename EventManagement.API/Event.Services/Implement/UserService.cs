using Event.Controller.Helper;
using Event.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings settings;

        
        public UserService(IOptions<AppSettings> _settings)
        {
            settings = _settings.Value;
        }

        public UserInfo Authenticate(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                
                UserInfo user = new UserInfo()
                {
                    Id = new Guid().ToString(),
                    Email = "admin@events.com",
                    Role = "admin",
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "event"
                };

                JwtTokenHelper helper = new JwtTokenHelper(settings.Secret);
                return helper.GenerateUserToken(user);


            }
            return null;
        }
    }
}
