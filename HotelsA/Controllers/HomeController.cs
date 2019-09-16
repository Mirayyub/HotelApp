using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            return View();
        }

        
    }
}