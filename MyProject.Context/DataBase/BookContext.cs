using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Context.Model;

namespace Context.DataBase
{
    public class BookContext : DbContext
        {

            public DbSet<Book> Books { get; set; }

            public DbSet<Purchase> Purchases { get; set; }

            public DbSet<Shop> Shops { get; set; }

            public DbSet<ExceptionDetail> ExceptionDetails { get; set; }

        }


        //public class BookDbInitializer : DropCreateDatabaseIfModelChanges<BookContext>
        //{
        //    protected override void Seed(BookContext db)
        //    {
        //        db.Books.Add(new Book { Name = "1984", Author = "George Orwell", Price = 50 });
        //        db.Books.Add(new Book { Name = "Brave New World", Author = "Aldous Huxley", Price = 75 });
        //        db.Books.Add(new Book { Name = "It", Author = "Stephen King ", Price = 125 });
        //
        //        base.Seed(db);
        //    }
        //}
    }

