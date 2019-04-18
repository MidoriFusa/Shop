using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Shop.Models.Database;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shop.DataLayer
{
   public class dbcont : IdentityDbContext <User>
    {

        public dbcont()
            : base("DBConnection")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Place> Places { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPunct> OrderPuncts { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartPunct> PartPuncts { get; set; }
    }
}
