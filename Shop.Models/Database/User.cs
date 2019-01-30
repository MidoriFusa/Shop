using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Database
{
    public class User
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

       

        public ICollection<Order> Orders { get; set; }



        public User()
        {
            Orders = new List<Order>();
        }



    }
}
