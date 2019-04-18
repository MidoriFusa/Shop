using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{
    public class PartDto:BaseDto
    {
        public DateTime DateTime { get; set; }
        public double SumPrice { get; set; }
        public ICollection<PartPunctDto> partpunctsdto { get; set; }

        public PartDto()
        {
            partpunctsdto = new List<PartPunctDto>();
        }


    }
}
