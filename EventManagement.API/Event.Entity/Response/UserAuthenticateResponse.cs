using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entity
{
    public class UserAuthenticateResponse : ResponseBase
    {
        public bool IsAuthenticate { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UsersRoles { get; set; }
        public string UserID { get; set; }
    }
}
