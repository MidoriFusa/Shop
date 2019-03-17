using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
   public class PlaceDto:BaseDto
    {

        public ICollection<Product> products { get; set; }

        public PlaceDto()
        {
            products = new List<Product>();
        }


    }
}
