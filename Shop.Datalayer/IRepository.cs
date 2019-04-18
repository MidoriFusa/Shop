using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataLayer
{
    public interface IRepository<T>
        where T:class
    {

        IDbSet<T> GetAll();
        T GetByid(int id);

        void Create(T item);
        void Update(T item);

        void Delete(int id);

       


    }
}
