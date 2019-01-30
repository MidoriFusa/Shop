using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class Place
    {
       
        public int PlaceId { get; set; }
        public int Freeplace { get; set; }
      
       
        public ICollection<Product> Products { get; set; }
       
        public Place()
        {
            Products = new List<Product>();
           
        }
        
    }
}
