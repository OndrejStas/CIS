using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS.Controllers
{
    public class EvidenceController : Controller
    {
        //
        // GET: /Evidence/

        public ActionResult Index()
        {
            //return this.RedirectToAction("EvidenceOsob", "Evidence");
            return View("/Evidence/");
        }
        public ActionResult Evd()
        {

            //return this.RedirectToAction("EvidenceOsob", "Evidence");
            return View("EvidenceOsob");
        }
    }
}
