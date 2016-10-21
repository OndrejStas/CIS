using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS.Controllers
{
    public class MatrikaController : Controller
    {
        //
        // GET: /Matrika/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mt()
        {

            //return this.RedirectToAction("EvidenceOsob", "Evidence");
            return View("Matrika");
        }
    }
}
