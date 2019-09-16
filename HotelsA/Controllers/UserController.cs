using HotelsA.Data;
using HotelsA.Models;
using HotelsA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelsA.Controllers
{
    public class UserController : Controller
    {
        private HotelsAContext context = new HotelsAContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(VwLogin login)
        {
            //Login if data is valid
            if (ModelState.IsValid)
            {

                
                User user = context.Users.FirstOrDefault(u => u.UserName == login.UserName);
                if (user != null)
                {
                    if (user.Password == login.Password)
                    {
                        Session["UserLogin"] = true;
                        Session["UserId"] = user.Id;
                        return RedirectToAction("index", "home");
                    }
                }


            }

            return View(login);
        }
    }
}
