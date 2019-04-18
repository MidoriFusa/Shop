using Shop.BuisnessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public class CreateOrderPunctDto
    {
        public int? Id { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }




    }
}
