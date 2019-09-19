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
    public class CustomerController : BaseController
    {
        // GET: Customer
        public ActionResult Index()
        {
            
            var list = _context.Customers.OrderByDescending(c => c.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            
            var list = _context.Customers.OrderByDescending(c => c.Id).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            

            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
           
            Customer customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }




            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            

            if (ModelState.IsValid)
            {
                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }


            return View(customer);
        }

        public ActionResult Delete(int id)
        {
           
            Customer customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}