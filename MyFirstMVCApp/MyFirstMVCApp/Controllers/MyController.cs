using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApp.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Name()
        {
            ViewBag.Message = "I'm Eugene";

            return View();
        }

        public ActionResult Phone()
        {
            ViewBag.Message = "Phone number";

            return View();
        }
    }
}