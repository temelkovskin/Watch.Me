using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Watch.Me.Models;
using Watch.Me.Models.ViewModels;

namespace Watch.Me.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();


        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            //toDO fix

            bool isAdmin = User.IsInRole("admin");
            //if (isAdmin)
            //{
            //    return View("~/Views/Admin/AdminHome.cshtml");
            //}

            var allVideos = _dbContext.Videos
                .Where(v => v.IsApproved.Equals(true))
                .Select(x => new UploadedVideos()
            {
                Id = x.Id,
                Url = x.Url,
                VideoTitle = x.VideoTitle
            });

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult WatchVideo()
        {
            return View();
        }
    }
}