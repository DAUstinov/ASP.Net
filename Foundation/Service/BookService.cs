using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repositories;
using Context.Model;
using Context.DataBase;

namespace Foundation.Service
{
    
    public class BookService
    {

        UnitOfWork unitOfWork;

        public BookService()
        {
             
           unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Book> GetBooks()
        {
             return unitOfWork.Books.GetAll();
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return unitOfWork.Purchases.GetAll();
        }

        public void AddBook(Book book)
        {
            unitOfWork.Books.Create(book);
            unitOfWork.Save();
        }

        public void AddPurchase(Purchase purchase)
        {
            unitOfWork.Purchases.Create(purchase);
        }

        
    }
}
