using Realt.Models;
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
        private ApplicationContext appContext = new ApplicationContext();
        public static object mutex;

        [HttpGet]
        public ActionResult GetUsers()
        {
            IEnumerable<User> users = appContext.Users.AsEnumerable();
            return View(users);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            User user = appContext.Users.Find(id);
            foreach (var item in user.Roles)
            {
                var role = appContext.Roles.Find(item.RoleId);
                if (role.Name == "Admin") { return RedirectToAction("GetUsers"); }
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(string id)
        {
            User user = appContext.Users.Find(id);
            appContext.Advertisements.RemoveRange(user.Advertisements);
            appContext.Users.Remove(user);
            appContext.SaveChanges();
            return RedirectToAction("GetUsers");
        }

        [HttpGet]
        public ActionResult Ban(string id)
        {
            User user = appContext.Users.Find(id);
            if (!user.LockoutEnabled)
            {
                foreach (var item in user.Roles)
                {
                    var role = appContext.Roles.Find(item.RoleId);
                    if (role.Name == "Admin") { return RedirectToAction("GetUsers"); }
                }
                user.LockoutEnabled = true;
                if (TryUpdateModel(user, "", new string[] { "LockoutEnabled" }))
                    appContext.SaveChanges();
            }
            return RedirectToAction("GetUsers");
        }

        [HttpGet]
        public ActionResult Unban(string id)
        {
            User user = appContext.Users.Find(id);
            if (user.LockoutEnabled)
            {
                user.LockoutEnabled = false;
                if (TryUpdateModel(user, "", new string[] { "LockoutEnabled" }))
                    appContext.SaveChanges();
            }
            return RedirectToAction("GetUsers");
        }
    }
}