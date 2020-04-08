using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entity
{
    public class UserDTO
    {
        #region "Constructor"

        public UserDTO() { }
        public UserDTO(UserInfo _user)
        {
            this.FirstName = _user.FirstName;
            this.Email = _user.Email;
            this.UserName = _user.FirstName;
            this.LastName = _user.LastName;
            this.Role = _user.Role;
            this.UserId = _user.Id;
            this.Token = _user.Token;

        }

        #endregion
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }

}
