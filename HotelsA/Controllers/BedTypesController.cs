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
    public class BedTypesController : BaseController
    {
        // GET: BedTypes
        [HttpGet]
        public ActionResult Index()
        {
           
            var list = _context.BedTypes.OrderByDescending(c => c.Id).ToList();
            return View(list);

        }
        [HttpGet]
        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("UserRol").FirstOrDefault(u => u.token == cookie);
            if (user.UserRol.UserType == "Restorant")

            {

                return RedirectToAction("index", "home");

            }
            if (user.UserRol.UserType == "Qebul")

            {

                return RedirectToAction("index", "home");

            }

            ViewBag.BedTypes = _context.BedTypes.ToList();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(BedType bedtype)
        {

            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("UserRol").FirstOrDefault(u => u.token == cookie);
            if (user.UserRol.UserType == "Restorant")

            {

                return RedirectToAction("index", "home");

            }
            if (user.UserRol.UserType == "Qebul")

            {

                return RedirectToAction("index", "home");

            }
            if (ModelState.IsValid)
            {
                _context.BedTypes.Add(bedtype);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            return View(bedtype);
        }

        public ActionResult Edit(int id)
        {
           

            BedType BedType = _context.BedTypes.Find(id);

            if (BedType == null)
            {
                return HttpNotFound();
            }

            ViewBag.BedTypes = _context.BedTypes.ToList();
            return View(BedType);
        }

        [HttpPost]
        public ActionResult Edit(BedType BedType)
        {
           
            if (ModelState.IsValid)
            {
                _context.Entry(BedType).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(c => c.TypeName).ToList();

            return View(BedType);
        }

        public ActionResult Delete(int id)
        {

            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("UserRol").FirstOrDefault(u => u.token == cookie);
            
                if (user.UserRol.UserType == "Restorant")

            {

                return RedirectToAction("index", "home");

            }
            if (user.UserRol.UserType == "Qebul")

            {

                return RedirectToAction("index", "home");

            }
            BedType BedType = _context.BedTypes.Find(id);

            if (BedType == null)
            {
                return HttpNotFound();
            }

            _context.BedTypes.Remove(BedType);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
