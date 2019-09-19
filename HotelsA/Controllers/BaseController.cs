using HotelsA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public readonly HotelsContext _context;

        public BaseController()
        {
            _context = new HotelsContext();

            
        }
       

    }
}