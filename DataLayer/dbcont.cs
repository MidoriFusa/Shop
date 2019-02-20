using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Shop.Models.Database;

namespace DataLayer
{
   public class dbcont : DbContext
    {

        public dbcont()
            : base("DBConnection")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Place> Places { get; set; }

    }
}
