using HotelsA.Data;
using HotelsA.Models;
using HotelsA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelsA.Controllers
{
    public class UserController : Controller
    {

        // GET: Login

        private readonly HotelsAContext _context;

        public UserController()
        {
            _context = new HotelsAContext();
        }


        //Index page view
        public ActionResult Index()
        {
            return View();
        }


        //Index page login submit form
        [HttpPost]
        public ActionResult Index(VwLogin login)
        {
            //Login if data is valid
            if (ModelState.IsValid)
            {

                //Find username from db
                User user = _context.Users.FirstOrDefault(u => u.UserName == login.UserName);
                if (user != null)
                {
                    if (user.Password == login.Password)
                    {
                        //Create user login session
                        Session["UserLogin"] = true;
                        Session["UserId"] = user.Id;
                        return RedirectToAction("index", "home");
                    }
                }


            }

            return View(login);
        }

        //logout
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "user");
        }
    }
}

