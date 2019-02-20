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
      private PlaceRepository placerepo;
      private ProductRepository prodrepo;

        public ProductRepository prods
        {

            get
            {
                if (prodrepo == null)
                {
                    prodrepo = new ProductRepository(context);
                }
                return prodrepo;
            }

        }

        public PlaceRepository Places
        {
            get
            {
                if (placerepo == null)
                {
                    placerepo = new PlaceRepository(context);
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
