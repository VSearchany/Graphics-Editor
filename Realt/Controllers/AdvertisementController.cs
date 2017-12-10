using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtApp.Controllers
{
    public class AdvertisementController : Controller
    {
        [HttpGet]
        public ActionResult Index()     //GetAllAds
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()       //GetAllUsersAds
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get(int id)   //GetEditingForm
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {
            return View();
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