using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
   public  class PartPunct
    {

        public int id { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

        public int Count { get; set; }


    }
}
