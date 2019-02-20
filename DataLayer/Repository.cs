using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models.Database;
using System.Data.Entity;

namespace DataLayer
{
   public class ProductRepository:IRepository<Product>
    {
        private dbcont db;

        public ProductRepository(dbcont context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product GetByid(int id)
        {
            return db.Products.Find(id);
        }

        public void Create (Product products)
        {
            db.Products.Add(products);
        }

        public void Update (Product products)
        {
            db.Entry(products).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product products = db.Products.Find(id);
            if (products != null)
            {
                db.Products.Remove(products);
            }
        }


      

      
    }


    public class PlaceRepository : IRepository<Place>
    {

        private dbcont db;

        public  PlaceRepository(dbcont context)
        {

            this.db = context;

        }


        public void Create(Place item)
        {
            db.Places.Add(item);
        }

        public void Delete(int id)
        {
            Place places = new Place();
            if (places!= null)
            {
                db.Places.Remove(places);
            }
        }

        public IEnumerable<Place> GetAll()
        {
           return db.Places;
        }

        public Place GetByid(int id)
        {
            return db.Places.Find(id);
        }

        public void Update(Place item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }

}
