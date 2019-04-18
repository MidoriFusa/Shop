using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public class CreatePartPunctDto
    {

        public int? Id { get; set; }
        public CreateProductDto product { get; set; }

        public PlaceUpdateDto place { get; set; }

        public int Count { get; set; }


    }
}
