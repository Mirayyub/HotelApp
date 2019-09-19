using HotelsA.Data;
using HotelsA.Models;
using HotelsA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelsA.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public readonly HotelsContext _context;

        public LoginController()
        {
            _context = new HotelsContext();
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (ModelState.IsValid)
            {
                
                User user = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == login.UserName.ToLower());
                if (user != null)
                {
                    if (user.Password == login.Password)
                    {
                        var u = Guid.NewGuid().ToString();
                        user.token = u;
                        _context.SaveChanges();

                        Response.Cookies["cookie"].Value = user.token;
                        Response.Cookies["cookie"].Expires = DateTime.Now.AddDays(1);
                        return RedirectToAction("index", "home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Summary", "E-poçt və ya Şifrə yanlışdır");
                }
            }
            return View(login);

            
            }
        public ActionResult Logout()
        {
            if (Request.Cookies["cookie"] != null)
            {
                HttpCookie cookie = new HttpCookie("cookie");
                cookie.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("index", "login");
        }
    }
}