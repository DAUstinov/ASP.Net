using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext db = new BookContext();

        UnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Book()
        {
           /* IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;*/

            var books = unitOfWork.Books.GetAll();

            ViewBag.books = books;

            return View();
        }

        [HttpGet]
        public ActionResult NewBook()
        {
             
            return View();
        }

        [HttpPost]
        public async Task<RedirectResult> NewBook(Book book)
        {
            db.Books.Add(book);

            await db.SaveChangesAsync();

            return Redirect("Book");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            
            return View();
        }

        [HttpPost]
        public async Task<RedirectResult> Buy(Purchase purchase)
        {
            purchase.Date = DateTime.UtcNow;
            db.Purchases.Add(purchase);

            await db.SaveChangesAsync();

            return Redirect("~/Home/Buyer");
        }

        public ActionResult Buyer()
        {
            IEnumerable<Purchase> purchases = db.Purchases;
            ViewBag.Purchases = purchases;
            return View();
        }





        public ActionResult Authorization()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}