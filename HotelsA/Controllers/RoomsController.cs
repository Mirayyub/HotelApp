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
    public class RoomsController : Controller
    {
        private HotelsAContext _context = new HotelsAContext();

        // GET: Rooms
        public ActionResult Index()
        {
            var rooms = _context.Rooms.Include(r => r.BedType);
            return View(rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = _context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            ViewBag.BedTypeId = new SelectList(_context.BedTypes, "Id", "TypeName");
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Price,Status,PersonCapacity,ChildCapacity,Desc,BedTypeId")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BedTypeId = new SelectList(_context.BedTypes, "Id", "TypeName", room.BedTypeId);
            return View(room);
        }

        // GET: Rooms/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = _context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.BedTypeId = new SelectList(_context.BedTypes, "Id", "TypeName", room.BedTypeId);
            return View(room);
        }

        // POST: Rooms/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Price,Status,PersonCapacity,ChildCapacity,Desc,BedTypeId")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(room).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BedTypeId = new SelectList(_context.BedTypes, "Id", "TypeName", room.BedTypeId);
            return View(room);
        }

        // GET: Rooms/Delete/
        public ActionResult Delete(int id)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
           
            Room room = _context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Rooms/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserLogin"] == null)
            {
                return RedirectToAction("index", "user");
            }
            Room room = _context.Rooms.Find(id);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
