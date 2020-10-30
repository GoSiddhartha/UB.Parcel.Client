using System;
using System.Collections.Generic;
using System.Text;

namespace UB.Parcel.Client.User
{
    public class User
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string UserName;

        public string AccessToken;
        public int ExpiresIn;
        public string RefreshToken;

        public Role Roles;

        public class Role
        {
            public int Id;
            public string Name;
            public string Description;
            public string[] Permissions;
        }
    }

    public User MapUserDomanin()
    {

    }

}
