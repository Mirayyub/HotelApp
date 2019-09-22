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
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {

            var list = _context.Categories.OrderByDescending(c => c.Id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Category category)
        {

            if (_context.Categories.Any(b => b.CategoryName == category.CategoryName))
            {
                ModelState.AddModelError("!", "Bu adda kateqoriya artıq mövcuddur");

            }else if(ModelState.IsValid)
            {
                 
                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            return View(category);
        }
        
        public ActionResult Edit(int id)
        {
            
            Category category = _context.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(category);
        }
        [Auth]
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            
            if (ModelState.IsValid)
            {
                _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();

            return View(category);
        }
        [Auth]
        public ActionResult Delete(int id)
        {

            Category category = _context.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }

}