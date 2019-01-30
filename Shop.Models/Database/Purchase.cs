using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public ICollection<PurchaseLine> Lines { get; set; }
        public Purchase()
        {
            Lines = new List<PurchaseLine>();
        }
    }
}
