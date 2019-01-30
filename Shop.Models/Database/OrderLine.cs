using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class OrderLine
    {
        
        public int OrderLineId { get; set; }
        public int? OrderId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public int OrderesCount { get; set; }
        public int Price { get; set; }



    }
}
