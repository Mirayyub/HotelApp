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
    public class UserrolController : BaseController
    {
        // GET: Userrol
        
        public ActionResult Index()
        {
            
            var list = _context.UserRols.OrderByDescending(g => g.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            
            ViewBag.Groups = _context.UserRols.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRol userrol)
        {
            
            if (ModelState.IsValid)
            {
                
                _context.UserRols.Add(userrol);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            return View(userrol);
        }

        public ActionResult Edit(int id)
        {
            
            UserRol rol = _context.UserRols.Find(id);

            if (rol == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserRols = _context.UserRols.ToList();
            return View(rol);
        }

        [HttpPost]
        public ActionResult Edit(UserRol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.UserRols.OrderBy(u => u.UserType).ToList();
            return View(rol);

        }


        public ActionResult Delete(int id)
        {
           
            UserRol rol = _context.UserRols.Find(id);

            if (rol == null)
            {
                return HttpNotFound();
            }

            _context.UserRols.Remove(rol);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}