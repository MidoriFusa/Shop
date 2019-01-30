using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class Order
    {

        public int OrderId { get; set; }
        public int? UserId { get; set; }

        public User User { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DateTime { get; set; }
        public bool InTransit { get; set; }

        public ICollection<OrderLine> ordersLines { get; set; }
        public Order()
        {
            ordersLines = new List<OrderLine>();
        }

    }
}
