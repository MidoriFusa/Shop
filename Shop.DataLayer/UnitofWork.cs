using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataLayer
{
    public class UnitOfWork : IDisposable
    {
      private dbcont context = new dbcont();
      private Repository<Place> placerepo;
      private Repository<Product> prodrepo;
      private Repository<User> userrepo;
      private Repository<Order> orderrepo;
      private Repository<OrderPunct> orderpunctrepo;
      private Repository<PartPunct> partpunctrepo;
      private Repository<Part> partrepo;

        public Repository<Product> prods
        {

            get
            {
                if (prodrepo == null)
                {
                    prodrepo = new Repository<Product>(context);
                }
                return prodrepo;
            }

        }

        public Repository<Place> Places
        {
            get
            {
                if (placerepo == null)
                {
                    placerepo = new Repository<Place>(context);
                }
                return placerepo;
            }
        }

        public Repository<User> users
        {
            get
            {
                if (userrepo== null)
                {
                    userrepo = new Repository<User>(context);
                }
                return userrepo;
            }
        }

        public Repository<Order> orders
        {
            get
            {
                if (orderrepo == null)
                {
                    orderrepo = new Repository<Order>(context);
                }
                return orderrepo;
            }
        }

        public Repository<OrderPunct> orderpuncts
        {
            get
            {
                if  (orderpunctrepo==null)
                {
                    orderpunctrepo = new Repository<OrderPunct>(context);
                }
                return orderpunctrepo;
            }
        }


        public Repository<Part> parts
        {
            get
            {
                if (partrepo == null)
                {
                    partrepo = new Repository<Part>(context);
                }
                return partrepo;
            }
        }


        public Repository<PartPunct> partpuncts
        {
            get
            {
                if (partpunctrepo==null)
                {
                    partpunctrepo = new Repository<PartPunct>(context);
                }
                return partpunctrepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

      

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();

                }



                this.disposedValue = true;
            }
        }
        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }
}
