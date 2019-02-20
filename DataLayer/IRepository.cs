using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    interface IRepository<T>
        where T:class
    {

        IEnumerable<T> GetAll();
        T GetByid(int id);

        void Create(T item);
        void Update(T item);

        void Delete(int id);

       


    }
}
