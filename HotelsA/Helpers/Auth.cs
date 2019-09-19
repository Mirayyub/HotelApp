using HotelsA.Data;
using HotelsA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelsA.Helpers
{
    public class Auth : ActionFilterAttribute
    {
        private HotelsContext context;
        public Auth()
        {
            context = new HotelsContext();
        }
        public int UserRolId { get; set; }
        public UserRol UserRol { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Request.Cookies["cookie"] == null)
            {
                filterContext.Result = new RedirectResult("/login");
                return;
            }

            string token = HttpContext.Current.Request.Cookies["cookie"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.token == token);

            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "login" },
                    { "action", "index" }
               });
            }

        }
    } }