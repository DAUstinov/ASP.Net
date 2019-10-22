using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Model
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int BookId { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public Book Book { get; set; }
        public DateTime Date { get; set; }
    }
}
