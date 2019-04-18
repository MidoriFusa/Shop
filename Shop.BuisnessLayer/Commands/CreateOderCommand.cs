using Shop.BuisnessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Commands
{
    public class CreateOderCommand
    {
        public int? Id { get; set; }

        public string Name { get; set; }
       

        public List<CreateOrderPunctCommand> Orderpuncts { get; set; }

    }
}
