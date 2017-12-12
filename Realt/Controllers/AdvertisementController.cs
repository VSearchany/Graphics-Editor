using Microsoft.AspNet.Identity.Owin;
using Realt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Realt.Controllers
{
    [Authorize]
    public class AdvertisementController : Controller
    {
        private ApplicationContext appContext = new ApplicationContext();
        private UserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Advertisement> ads = appContext.Advertisements.Include("User").OrderByDescending(ad => ad.Date);
            return View("Show", ads);
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Advertisement> userAds = appContext.Advertisements.Include("User").Where(ad => ad.User.UserName == User.Identity.Name).OrderByDescending(ad => ad.Date).AsEnumerable();
            return View("Show", userAds);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Search(SearchAdvertisementModel model)
        {
            if (model.Location != null)
            {
                model.Location = model.Location.Trim(' ', ',', '.', '-', '/', '\\');
            }
            if (model.MaxCost <= 0 || model.MaxSize < model.MinSize)
            {
                model.MaxCost = float.MaxValue;
            }
            if (model.MaxSize <= 0 || model.MaxSize < model.MinSize)
            {
                model.MaxSize = float.MaxValue;
            }
            IEnumerable<Advertisement> ads = appContext.Advertisements.Include("User")
                .Where(ad => (model.Location != null ? ad.Location.Contains(model.Location) : true)
                && (ad.Price >= model.MinCost)
                && (ad.Price <= model.MaxCost)
                && (ad.Size >= model.MinSize)
                && (ad.Size <= model.MaxSize))
                .OrderByDescending(ad => ad.Date);
            return View("Show", ads);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Advertisement newAd = new Advertisement();
            return View(newAd);
        }

        [HttpPost]
        public ActionResult Create(Advertisement advertisement)
        {
            User currentUser = appContext.Users.First(user => user.UserName == User.Identity.Name);
            advertisement.User = currentUser;
            advertisement.UserId = currentUser.Id;
            advertisement.Date = DateTime.Now.ToString();
            appContext.Advertisements.Add(advertisement);
            appContext.SaveChanges();
            return RedirectToAction("Get");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Advertisement advertisement = appContext.Advertisements.Find(id);
            return View(advertisement);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int id)
        {
            Advertisement advertisement = appContext.Advertisements.Find(id);
            advertisement.Date = DateTime.Now.ToString();
            if (TryUpdateModel(advertisement, "", new string[] { "Location", "Size", "Date", "Price", "Name", "Kind" }))
                appContext.SaveChanges();
            return RedirectToAction("Get");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Advertisement advertisement = appContext.Advertisements.Find(id);
            return View(advertisement);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            Advertisement advertisement = appContext.Advertisements.Find(id);
            appContext.Advertisements.Remove(advertisement);
            appContext.SaveChanges();
            return RedirectToAction("Get");
        }
    }
}