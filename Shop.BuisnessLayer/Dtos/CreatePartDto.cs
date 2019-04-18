using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
   public  class CreatePartDto
    {
        public int? Id { get; set; }
        public string PartNumber { get; set; }
        public DateTime DateTime { get; set; }
        public double SumPrice { get; set; }
        public ICollection<CreatePartPunctDto> partpunctsdto { get; set; }

        public CreatePartDto()
        {
            partpunctsdto = new List<CreatePartPunctDto>();
        }

    }
}
