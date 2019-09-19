using HotelsA.Helpers;
using HotelsA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    [Auth]
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
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
            var list = _context.Users.Include("UserRol").OrderByDescending(r => r.Id).ToList();
            return View(list);
            
        }
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

            ViewBag.UserRol = _context.UserRols.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User ssr = _context.Users.Include("UserRol").FirstOrDefault(u => u.token == cookie);
            if (ssr.UserRol.UserType == "Restorant")

            {

                return RedirectToAction("index", "home");

            }
            if (ssr.UserRol.UserType == "Qebul")

            {

                return RedirectToAction("index", "home");

            }


            if (!ModelState.IsValid)
            {
                return View(user);
            }
            if (_context.Users.Any(u => u.UserName == user.UserName))
            {
                ModelState.AddModelError("UserName", user.UserName + " İstifadəçi artıq mövcuddur.");
                return View(user);
            }
            if (ModelState.IsValid)
            {
                
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("index");
                
            }

            return View(user);






        }


        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User ssr = _context.Users.Include("UserRol").FirstOrDefault(u => u.token == cookie);
            if (ssr.UserRol.UserType == "Restorant")

            {

                return RedirectToAction("index", "home");

            }
            if (ssr.UserRol.UserType == "Qebul")

            {

                return RedirectToAction("index", "home");

            }

            User user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserRol = _context.UserRols.ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User ssr = _context.Users.Include("UserRol").FirstOrDefault(u => u.token == cookie);
            if (ssr.UserRol.UserType == "Restorant")

            {

                return RedirectToAction("index", "home");

            }
            if (ssr.UserRol.UserType == "Qebul")

            {

                return RedirectToAction("index", "home");

            }
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index","user");
            }

            ViewBag.UserRol = _context.UserRols.OrderBy(u => u.UserType).ToList();
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User ssr = _context.Users.Include("UserRol").FirstOrDefault(u => u.token == cookie);
            if (ssr.UserRol.UserType == "Restorant")

            {

                return RedirectToAction("index", "home");

            }
            if (ssr.UserRol.UserType == "Qebul")

            {

                return RedirectToAction("index", "home");

            }
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
