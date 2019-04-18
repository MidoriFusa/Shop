using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class Place
    {

        public int Id { get; set; }

     
        public string Name { get; set; }
      
        public virtual ICollection<Product> Products { get; set; }

        public Place()
        {
            Products = new HashSet<Product>();
        }



    }
}
