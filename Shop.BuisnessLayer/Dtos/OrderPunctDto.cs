using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public class OrderPunctDto
    {
        public int? Id { get; set; }

        public int ProductId { get; set; }
        public decimal SellPrice { get; set; }

        public string ProductName { get; set; }
        public int Count { get; set; }

        // все ок ненадо хендлеров 




    }
}
