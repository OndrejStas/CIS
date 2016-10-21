using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS.Controllers
{
    public class CISController : Controller
    {
        //
        // GET: /CIS/

        public ActionResult Index()
        {
            Classes.User.UserInfo usr = new Classes.User.UserInfo();
            usr = (Classes.User.UserInfo)Session["UserInfo"];
            if (!usr.authorized) return Content("Neoprávněný přístup", "text/html");
            return View("Index");
        }
        public ActionResult Login()
        {
            return View("Login");
        }

    }
}
