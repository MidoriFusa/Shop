using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class User:IdentityUser
    {
    
        public string Name { get; set; }
        public string Address { get; set; }
  
        public ICollection<Order> orders { get; set; }

        public User()
        {
            orders = new List<Order>();
        }
    }
}
