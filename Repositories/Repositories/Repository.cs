
using System.Collections.Generic;
using Repositories.Interfaces;
using Context.DataBase;
using Context.Model;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookContext db;

        public BookRepository(BookContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            //if (book != null)
                db.Books.Remove(book);
            db.SaveChanges();
        }
    }

    public class PurchaseRepository : IRepository<Purchase>
    {
        private BookContext db;

        public PurchaseRepository(BookContext context)
        {
            this.db = context;
        }

        public IEnumerable<Purchase> GetAll()
        {
            return db.Purchases.Include(o => o.Book);
        }

        public Purchase Get(int id)
        {
            return db.Purchases.Find(id);
        }

        public void Create(Purchase purchase)
        {
            db.Purchases.Add(purchase);
        }

        public void Update(Purchase purchase)
        {
            db.Entry(purchase).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            if (purchase != null)
                db.Purchases.Remove(purchase);
        }
    }
}
