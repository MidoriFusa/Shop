using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class PurchaseLine
    {
      
        public int PurchaseLineId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
   

        public int? PurhaseId { get; set; }
        public Purchase Purchase { get; set; }
       
    }
}
