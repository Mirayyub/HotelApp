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
    
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            
            
            return View();
        }

       
    }
}