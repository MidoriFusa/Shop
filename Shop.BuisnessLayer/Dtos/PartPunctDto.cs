using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public class PartPunctDto
    {
        public int? Id { get; set; }
        public ProductDto product { get; set; }

        public PlaceDto place { get; set; }

        public int Count { get; set; }



    }
}
