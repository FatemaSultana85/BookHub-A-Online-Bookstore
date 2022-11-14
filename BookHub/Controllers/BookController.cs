using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookHub.Models;

namespace BookHub.Controllers
{
    public class BookController : Controller
    {
        BookHubEntities db = new BookHubEntities();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book()
        {
            var list = db.BookDetails;
            return View(list);
        }

        public ActionResult ThrillerBooks()
        {
            string category = "Detective";
            var list = from r in db.BookDetails
                       where r.BookCategory == category
                       select r;
            return View(list);
        }

        public ActionResult DetectiveBooks()
        {
            string category = "Detective";
            var list = from r in db.BookDetails
                       where r.BookCategory == category
                       select r;
            return View(list);
        }

        public ActionResult ScienceFictionBooks()
        {
            string category = "Science Fiction";
            var list = from r in db.BookDetails
                       where r.BookCategory == category
                       select r;
            return View(list);
        }




    }
}