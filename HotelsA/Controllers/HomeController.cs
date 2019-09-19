using HotelsA.Helpers;
using HotelsA.Models;
using HotelsA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    [Auth]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            
            ViewBag.User = _context.Users.ToList();
            ViewBag.Userrol = _context.UserRols.ToList();
            return View();
        }

       
    }
}