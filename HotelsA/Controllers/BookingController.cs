using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    public class BookingController : Controller
    {
        private readonly HotelsAContext _context;

        public BookingController()
        {
            _context = new HotelsAContext();
        }
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
    }
}