using HotelsA.Helpers;
using HotelsA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    [Auth]
    public class BookingController : BaseController
    {
        // GET: Booking
        [HttpGet]
        public ActionResult Index()
        {
            

            var list = _context.Bookings.Include("Room").Include("Customer").Include("User").ToList();

            return View(list);
        }


        [HttpGet]
        public ActionResult Create()
        {

           
            ViewBag.Food = _context.Foods.OrderBy(f =>f.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();

            return View();
        }



        [HttpPost]
        public ActionResult Create(Booking booking)
        {

           

            var room = _context.Rooms.Find(booking.RoomId);

            TimeSpan calc = booking.CheckedOut.Subtract(booking.CheckedIn);

            booking.Price = calc.Days * room.Price;



            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            ViewBag.Food = _context.Foods.OrderBy(f => f.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();

            return View(booking);
        }



        public ActionResult Edit(int id)
        {

            Booking booking = _context.Bookings.Find(id);

            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();
            ViewBag.Food = _context.Foods.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();

            return View(booking);


        }


        [HttpPost]
        public ActionResult Edit(Booking book, RestourantOrder restourant)
        {
          
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();
            ViewBag.Food = _context.Foods.OrderBy(f => f.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();
            return View(book);

        }
        public ActionResult Delete(int id)
        {
            
            Booking booking = _context.Bookings.Find(id);

            if (booking == null)
            {
                return HttpNotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}