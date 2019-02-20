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

        public int PlaceId { get; set; }

        [Required]
        [StringLength(4,MinimumLength =2)]
        public string PlaceName { get; set; }
      
        public ICollection<Product> products { get; set; }

        public Place()
        {
            products = new List<Product>();
        }



    }
}
