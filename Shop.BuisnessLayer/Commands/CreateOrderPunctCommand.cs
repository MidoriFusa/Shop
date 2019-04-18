using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Commands
{
   public  class CreateOrderPunctCommand
    {
        public int? Id { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }






    }
}
