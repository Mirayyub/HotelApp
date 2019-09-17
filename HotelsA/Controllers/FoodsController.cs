using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelsA.Data;
using HotelsA.Models;

namespace HotelsA.Controllers
{
    public class FoodsController : Controller
    {
        private HotelsAContext _context = new HotelsAContext();

        // GET: Foods
        public ActionResult Index()
        {
            var foods = _context.Foods.Include(f => f.Category);
            return View(foods.ToList());
        }

       

        // GET: Foods/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Foods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,IsDelete,CategoryId")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "CategoryName", food.CategoryId);
            return View(food);
        }

        // GET: Foods/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = _context.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "CategoryName", food.CategoryId);
            return View(food);
        }

        // POST: Foods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,IsDelete,CategoryId")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(food).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "CategoryName", food.CategoryId);
            return View(food);
        }

        // GET: Foods/Delete/
        public ActionResult Delete(int id)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }

            Food food = _context.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            
            _context.Foods.Remove(food);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Foods/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = _context.Foods.Find(id);
            _context.Foods.Remove(food);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
