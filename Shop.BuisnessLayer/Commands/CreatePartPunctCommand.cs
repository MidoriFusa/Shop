using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Commands
{
   public class CreatePartPunctCommand
    {
        public int? Id { get; set; }
        public CreateProductCommand product { get; set; }

        public UpdatePlaceCommand place { get; set; }

        public int Count { get; set; }




    }
}
