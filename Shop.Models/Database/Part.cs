using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public  class Part
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedDate { get; set; }
   
        public virtual ICollection<PartPunct> PartPuncts { get; set; }

        public Part()
        {
            PartPuncts = new HashSet<PartPunct>();
        }
    }
}
