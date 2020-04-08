using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entity
{
    public class ProfileInfo : UserInfo
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }

        public string Gender { get; set; }
        public string ContactNumber { get; set; }
    }
}
