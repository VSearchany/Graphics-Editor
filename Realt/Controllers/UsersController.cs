using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Realt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            
            return View();
        }

        [HttpPut]
        public ActionResult Ban()
        {
            return View();
        }

        [HttpPut]
        public ActionResult Unban()
        {
            return View();
        }
    }
}