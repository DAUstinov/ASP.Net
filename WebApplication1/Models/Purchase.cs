using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int BookId { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public Book Book { get; set; }
        public DateTime Date { get; set; }
    }
}