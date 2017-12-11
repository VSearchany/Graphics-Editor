using Microsoft.AspNet.Identity.Owin;
using RealtApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtApp.Controllers
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
        public ActionResult Index()     //GetAllAds
        {
            IEnumerable<Advertisement> ads = appContext.Advertisements.Include("User");
            return View(ads);
        }

        [HttpGet]
        public ActionResult Get()       //GetAllUsersAds
        {
            IEnumerable<Advertisement> userAds = appContext.Advertisements.Include("User").Where(ad=> ad.User.UserName == User.Identity.Name).AsEnumerable();
            IEnumerable<Advertisement> ads = userAds;
            return View(ads);
        }

        //[HttpGet]
        //public ActionResult Get(int id)   //GetEditingForm
        //{
        //    return View();
        //}

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

        [HttpPut]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}