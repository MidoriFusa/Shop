using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
   public class Product 
    {
       
        public int ProductId { get; set; }
        public string ProductName { get; set; }
       
        public ICollection<Place> Places { get; set; }
       
        public Product()
        {
            Places = new List<Place>();
          
        }

       

    }
}
