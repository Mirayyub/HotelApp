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
    public class FoodController : BaseController
    {
        // GET: Food
        
        public ActionResult Index()
        {
           
            var list = _context.Foods.Include("Category").OrderByDescending(f => f.Id).ToList();
            return View(list);


        }

        public ActionResult Create()
        {
           
            ViewBag.Category = _context.Categories.ToList();
            return View();

        }
        [HttpPost]
        public ActionResult Create(Food food)
        {
           
            if (ModelState.IsValid)
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(food);
        }

        public ActionResult Edit(int id)
        {
           

            Food food = _context.Foods.Find(id);

            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = _context.Categories.ToList();

            return View(food);
        }

        [HttpPost]
        public ActionResult Edit(Food food)
        {
            
            if (ModelState.IsValid)
            {
                _context.Entry(food).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            ViewBag.Categories = _context.Categories.ToList();

            return View(food);

        }


        public ActionResult Delete(int id)
        {
            
            Food food = _context.Foods.Find(id);

            if (food == null)
            {
                return HttpNotFound();
            }
            _context.Foods.Remove(food);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}