using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork : IDisposable
    {
      private dbcont context = new dbcont();
      private Repository<Place> placerepo;
      private Repository<Product> prodrepo;

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
