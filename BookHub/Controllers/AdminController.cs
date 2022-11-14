using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookHub.Models;

namespace BookHub.Controllers
{
    public class AdminController : Controller
    {
        BookHubEntities db = new BookHubEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Administrator r)
        {
            var lg = db.Administrators.Where(a => a.AdminEmail.Equals(r.AdminEmail) && a.AdminPassword.Equals(r.AdminPassword)).FirstOrDefault();
            if (lg != null)
            {
                return RedirectToAction("AdminDashBoard", "Admin");
            }
            else
            {
                ViewBag.Message = "Login Unsuccessful!";
                return RedirectToAction("AdminLogin","Admin");
            }

        }

        public ActionResult AdminDashBoard()
        {
            return View();
        }

        public ActionResult BookList()
        {
            var temp = db.BookDetails.ToList();
            return View(temp);
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(BookDetail bDetails, HttpPostedFileBase ProdImgfile)
        {
            string ImgName = DateTime.Now.ToString("yymmsssfff") + ProdImgfile.FileName;
            ProdImgfile.SaveAs(Server.MapPath("~/BookImages/" + ImgName));
            bDetails.BookImage = "~/BookImages/" + ImgName;
            db.BookDetails.Add(bDetails);
            db.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.BookDetails.Find(id);
            TempData["imgPath"] = book.BookImage;
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, BookDetail bo)
        {
            if (file != null)
            {

            }
            else
            {
                bo.BookImage = TempData["imgPath"].ToString();
                db.Entry(bo).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    TempData["msg"] = "Data Updated";
                    return RedirectToAction("BookList");
                }
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            var res = db.BookDetails.Where(x => x.BookID == id).FirstOrDefault();
            db.BookDetails.Remove(res);
            db.SaveChanges();
            var list = db.BookDetails.ToList();
            return View("BookList", list);
        }

        public ActionResult ContactMessageList()
        {
            var msgList = db.ContactUs.ToList();
            return View(msgList);
        }


    }
}