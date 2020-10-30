using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UB.Parcel.Client.User
{
    public class UserDomain
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string UserName;

        public string AccessToken;
        public int ExpiresIn;
        public string RefreshToken;

        public Role Roles;

        public string message;
        public bool status;

        public class Role
        {
            public int Id;
            public string Name;
            public string Description;
            public string[] Permissions;
        }

        public class LoginRequest
        {
            public string username;
            public string password;
            public bool omitClaims;
        }

        public static UserDomain MapUserDomanin(string rawresponse)
        {
            dynamic json = JsonConvert.DeserializeObject(rawresponse);
            return new UserDomain();
        }
    }
}
