using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View(new AuthLogin
            {
            });
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form) //moves data from the form, to a controller
        {
            if (!ModelState.IsValid)
                return View(form);

            if (form.Username != "derrik")
            {
                ModelState.AddModelError("Username", "Username or password isn't correct");
                return View(form);
            }

            return Content("The form is valid");
        }
    }
}