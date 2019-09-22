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
    public class RestourantController : BaseController
    {
        // GET: Restourant
        public ActionResult Index()
        {
            var list = _context.RestourantOrders.Include("Room").Include("Food").Where(s => s.IsDelete == true).OrderBy(r => r.Room.Number).ToList();
            return View(list);
        }
        public ActionResult Create()
        {
           
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Food = _context.Foods.OrderByDescending(r => r.Name).ToList();

            return View();

        }
        [HttpPost]
        public ActionResult Create(RestourantOrder res)
        {
            

            if (ModelState.IsValid)
            {
                var food = _context.Foods.Find(res.FoodId);

                res.FoodTotalPrice = food.Price * res.FoodCount;

                ViewBag.Menu = _context.Foods.OrderByDescending(r => r.Name).ToList();
                res.IsDelete = true;
                _context.RestourantOrders.Add(res);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(res);

        }
        public ActionResult Edit(int Id)
        {
            
            RestourantOrder res = _context.RestourantOrders.Find(Id);

            if (res == null)
            {
                return HttpNotFound();

            }
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Food = _context.Foods.OrderByDescending(r => r.Name).ToList();

            return View(res);
        }

        [HttpPost]
        public ActionResult Edit(RestourantOrder res)
        {
           
            if (ModelState.IsValid)
            {
                var food = _context.Foods.Find(res.FoodId);

                res.FoodTotalPrice = food.Price * res.FoodCount;


                _context.Entry(res).State = System.Data.Entity.EntityState.Modified;
                res.IsDelete = true;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Room = _context.Rooms.OrderByDescending(s => s.Number).ToList();
            ViewBag.Menu = _context.Foods.OrderByDescending(s => s.Name).ToList();
            return View(res);

        }
        public ActionResult Delete(int id)
        {
            RestourantOrder rstp = _context.RestourantOrders.Find(id);

            if (rstp == null)
            {
                return HttpNotFound();
            }

            _context.RestourantOrders.Remove(rstp);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}