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
    public class UsersController : Controller
    {
        private HotelsAContext db = new HotelsAContext();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            var users = db.Users.Include(u => u.UserRol);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()

        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            ViewBag.UserRolId = new SelectList(db.UserRols, "Id", "UserType");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,UserName,Password,UserRolId")] User user)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserRolId = new SelectList(db.UserRols, "Id", "UserType", user.UserRolId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserRolId = new SelectList(db.UserRols, "Id", "UserType", user.UserRolId);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,UserName,Password,UserRolId")] User user)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserRolId = new SelectList(db.UserRols, "Id", "UserType", user.UserRolId);
            return View(user);
        }

        // GET: Users/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
