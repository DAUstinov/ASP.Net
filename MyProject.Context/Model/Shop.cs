using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Model
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string ShopAddress { get; set; }
        public string Name { get; set; }
        public bool Count { get; set; }
        public int BookId { get; set; }
    }
}
