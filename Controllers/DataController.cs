using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data;


namespace CIS.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Krty()
        {
            Classes.Authorisation auth = new Classes.Authorisation();
            Classes.User.UserInfo usr = Classes.User.GetUser("session");
            if (!auth.IsAuthorized(usr)) return Content(string.Empty, "text/plain");

            
            //return this.RedirectToAction("EvidenceOsob", "Evidence");
            CIS.Classes.DataModel.KrtyJson kj = new CIS.Classes.DataModel.KrtyJson();
            var jsonSerialiser = new JavaScriptSerializer();
            //kj.data=  CIS.Classes.DataApi
            CIS.Classes.DataMethods dm = new Classes.DataMethods();
            //kj.data = dm.GetKrty();
            //var json = jsonSerialiser.Serialize(kj);
            List<String[]> lst = new List<string[]>();
            List<Object[]> obl = new List<object[]>();
            lst = dm.GetKrtyS();
            obl = dm.GetKrtyO();
            var json = jsonSerialiser.Serialize(obl);
            string res = json.ToString();
            Response.ContentType = "text/plain";
            Response.Write(res);
            Response.End();
            return Content(res, "text/plain"); 
            //return View("EvidenceOsob");
        }

        public ActionResult Osoby()
        {

            return Content(Classes.DataApi.GetStringFromDt(Classes.DataMethods.GetOsoby()), "text/plain");
        
        }
    }
}
