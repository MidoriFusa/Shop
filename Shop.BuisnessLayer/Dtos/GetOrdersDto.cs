using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public  class GetOrdersDto:BaseDto
    {

        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal SumPrice { get; set; }

    }
}
