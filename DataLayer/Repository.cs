using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models.Database;
using System.Data.Entity;

namespace DataLayer
{
   public class Repository<T>:IRepository<T> where T:class
    {
        private dbcont db;

        public Repository(dbcont context)
        {
            this.db = context;
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetByid(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Create (T products)
        {
            db.Set<T>().Add(products);
        }

        public void Update (T products)
        {
            db.Entry(products).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T products = db.Set<T>().Find(id);
            if (products != null)
            {
                db.Set<T>().Remove(products);
            }
        }


      

      
    }


  

}
