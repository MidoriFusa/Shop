using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
   public  class PlaceProduct
    {

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }

    }
}
