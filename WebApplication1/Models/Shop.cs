using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string ShopAddress { get; set; }
        public bool Count { get; set; }
        public int BookId { get; set; }
    }
}