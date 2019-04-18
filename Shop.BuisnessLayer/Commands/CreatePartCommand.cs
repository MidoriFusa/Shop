using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Commands
{
    public class CreatePartCommand
    {

        public int? Id { get; set; }
        public string PartNumber { get; set; }
        public DateTime DateTime { get; set; }
        public double SumPrice { get; set; }
        public ICollection<CreatePartPunctCommand> partpunctsdto { get; set; }

        public CreatePartCommand()
        {
            partpunctsdto = new List<CreatePartPunctCommand>();
        }

    }
}
