using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookHub.Models;

namespace BookHub.Controllers
{
    public class UsersController : Controller
    {
        private BookHubEntities db = new BookHubEntities();

        // GET: Users
        //public ActionResult Index()
        //{
        //    return View(db.Users.ToList());
        //}

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User r)
        {
            User u = new User();

            u.UserFirstName = r.UserFirstName;
            u.UserLastName = r.UserLastName;
            u.UserPhoneNo = r.UserPhoneNo;
            u.UserEmail = r.UserEmail;
            u.UserPassword = r.UserPassword;
            u.ConfirmUserPassword = r.ConfirmUserPassword;


            var lg = db.Users.Where(a => a.UserEmail.Equals(r.UserEmail)).FirstOrDefault();
            if (lg != null)
            {
                //ViewData["msg"] = "This user email is already in use!";
                ModelState.AddModelError("UserEmail", "This email is already in use!");
                return RedirectToAction("Registration", "Users");
            }

            db.Users.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

            
            /*return View("Index")*/;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User r)
        {
            var lg = db.Users.Where(a => a.UserEmail.Equals(r.UserEmail) && a.UserPassword.Equals(r.UserPassword)).FirstOrDefault();
            if (lg != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Name = "Login Unsuccessful!";
                return RedirectToAction("Login");
            }
            
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserFirstName,UserLastName,UserEmail,UserPassword,UserAddress,UserPhoneNo")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserFirstName,UserLastName,UserEmail,UserPassword,UserAddress,UserPhoneNo")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
