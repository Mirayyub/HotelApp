using HotelsA.Helpers;
using HotelsA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    [Auth]
    public class RoomsController : BaseController
    {
        // GET: Rooms
        public ActionResult Index()
        {
            
            var list = _context.Rooms.Include("BedType").OrderByDescending(r => r.Id).ToList();
            return View(list);

        }

        public ActionResult Create()
        {
           
            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.TypeName).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
           
            if (room.File.ContentLength / 1024 / 1024 > 5)
            {
                ModelState.AddModelError("Şəkil", "Maksimum 5mb Şəkil Yükləyə Bilərsiniz");
            }

            if (ModelState.IsValid)
            {
                room.Photo = FileManager.Upload(room.File);
                room.Status = true;
                _context.Rooms.Add(room);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.TypeName).ToList();

            return View(room);
        }

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
            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.TypeName).ToList();
            return View(room);
        }
        public ActionResult Edit(int id)
        {
            
            Room room = _context.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();

            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.TypeName).ToList();
            return View(room);
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            
            if (room.File != null)
            {
                if (room.File.ContentLength / 1024 / 1024 > 4)
                {
                    ModelState.AddModelError("Şəkil", "Maksimum 4mb Şəkil Yükləyə Bilərsiniz");
                }
            }

            if (ModelState.IsValid)
            {
                if (room.File != null)
                {
                    FileManager.Delete(room.Photo);
                    room.Photo = FileManager.Upload(room.File);
                }

                _context.Entry(room).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.TypeName).ToList();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            

            Room room = _context.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();
            }

            if (room.File != null)
            {
                FileManager.Delete(room.Photo);

            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}