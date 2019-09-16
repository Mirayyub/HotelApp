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
    public class UserRolsController : Controller
    {
        private HotelsAContext _context = new HotelsAContext();

        // GET: UserRols
        public ActionResult Index()
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            return View(_context.UserRols.ToList());
        }

        // GET: UserRols/Details/5
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
            UserRol userRol = _context.UserRols.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // GET: UserRols/Create
        public ActionResult Create()
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            return View();
        }

        // POST: UserRols/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserType")] UserRol userRol)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            if (ModelState.IsValid)
            {
                _context.UserRols.Add(userRol);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRol);
        }

        // GET: UserRols/Edit/5
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
            UserRol userRol = _context.UserRols.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // POST: UserRols/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserType")] UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(userRol).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRol);
        }

        // GET: UserRols/Delete/5
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
            UserRol userRol = _context.UserRols.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // POST: UserRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            UserRol userRol = _context.UserRols.Find(id);
            _context.UserRols.Remove(userRol);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
