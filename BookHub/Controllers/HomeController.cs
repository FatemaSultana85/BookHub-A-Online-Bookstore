using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookHub.Models;

namespace BookHub.Controllers
{
    public class HomeController : Controller
    {
        private BookHubEntities db = new BookHubEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult OurTeam()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactU c)
        {
            ContactU u = new ContactU();

            u.UserName = c.UserName;
            u.UserEmail = c.UserEmail;
            u.Subject = c.Subject;
            u.Message = c.Message;

            db.ContactUs.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}