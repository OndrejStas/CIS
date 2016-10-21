using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS.Classes
{
    public class User
    {
        public class UserInfo
        {
            public string name = string.Empty;
            public string passwd = string.Empty;
            public string hash = string.Empty;
            public bool authorized = false;
        }

        public static UserInfo GetUser(string session)
        {
            UserInfo _res = new UserInfo();

            _res.name = "John Fake";
            _res.passwd = "Fake pasw";

            return _res;
        }


    }
}