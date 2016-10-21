using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS.Classes
{
    public class Authorisation
    {

        public static User.UserInfo Authorize(User.UserInfo user)
        {
            User.UserInfo _res = new User.UserInfo();
            // TODO zjisteni autorizace, vyplneni hash, smazani hesla
            user.authorized = true;
            user.hash = "XXXXXX123456789";
            user.passwd = string.Empty;
            _res = user;
            return _res;
        }

        public bool IsAuthorized(User.UserInfo person)
        {
            bool _res = false;
            // Docasne 

            //_res = true;
            return _res;

        }


    }
}