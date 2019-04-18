using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class Order
    {
        public int Id { get; set; }

        public string Number { get; set; }
        public DateTime CreatedDate { get; set; }
     


       
        public virtual ICollection<OrderPunct> OrderPuncts { get; set; }

        public Order()
        {
            OrderPuncts = new HashSet<OrderPunct>();
        }

    }
}
