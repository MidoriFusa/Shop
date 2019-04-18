using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class OrderPunct
    {
        public int Id { get; set; }

        public virtual Product Product { get; set; }

      
        public int ProductId { get; set; }
        public virtual Order Order { get; set; }


        public int OrderId { get; set; }
        public  int Count { get; set; }


        

    }
}
