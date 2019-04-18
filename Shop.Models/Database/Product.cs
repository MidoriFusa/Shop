using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class Product
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Length { get; set; }

        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        
        public virtual ICollection<Place> Places { get; set; }

        public Product()
        {
            Places = new HashSet<Place>();
        }


    }
}
