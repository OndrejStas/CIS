using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            Classes.User.UserInfo usr = new Classes.User.UserInfo();
            usr.authorized = true;
            Session["UserInfo"] = usr;
            return this.RedirectToAction("Index", "CIS");
            //return this.RedirectToAction("Login", "CIS");
           // return View("/CIS/Index");
        }

     
        public ActionResult Login()
        {
            Classes.User.UserInfo usr = new Classes.User.UserInfo();
            usr.passwd = Request["psw"];
            usr.name = Request["userid"];
            usr = Classes.Authorisation.Authorize(usr);
            if (!usr.authorized) return Content(string.Empty, "text/html");
            Session["UserInfo"] = usr;
            return this.RedirectToAction("Index", "CIS");
        }

        public ActionResult Local()
        {

            try
            {
               string cesta = ControllerContext.HttpContext.Server.MapPath("~/Content/Localisation/czech.json");
               using (StreamReader sr = new StreamReader(cesta))
                {
                    String content = sr.ReadToEnd();
                    return Content(content, "text/plain");
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debugger.Break();
            }
            return Content(string.Empty, "text/html");
        }
    }
}
