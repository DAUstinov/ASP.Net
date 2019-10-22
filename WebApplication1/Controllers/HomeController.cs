using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using WebApplication1.Filters;
using Context.DataBase;
using Context.Model;
using Repositories.Repositories;
using Foundation.Service;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext db = new BookContext();
        UnitOfWork unitOfWork;
        BookService bookService;

        public HomeController()
        {
            bookService = new BookService();
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Book()
        {
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
            bookService.AddBook(book);

            db.SaveChanges();

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

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            Book b = db.Books.Find(id);
            return View(b);
        }

        [HttpPost , ActionName ("DeleteBook")]
        public async Task<RedirectResult> DeleteConf(int id)
        {
            unitOfWork.Books.Delete(id);
            db.SaveChanges();
            return Redirect("~/Home/Book");
        }

        public ActionResult Authorization()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Test(int id)
        //{
        //    if (id > 3)
        //    {
        //        int[] mas = new int[2];
        //        mas[6] = 4;
        //    }
        //    else if (id < 3)
        //    {
        //        throw new Exception("id не может быть меньше 3");
        //    }
        //    else
        //    {
        //        throw new Exception("Некорректное значение для параметра id");
        //    }
        //    return View();
        //}

    }
}