using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return Content("Users");
        }
    }
}