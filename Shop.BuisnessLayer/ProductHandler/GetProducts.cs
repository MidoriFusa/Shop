using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.ProductHandler
{
    public class GetProducts : BaseHandler<List<Product>>
    {


        public GetProducts(UnitOfWork unitOfWork) : base(unitOfWork) { }




        public override HandlerResult<List<Product>> Execute()
        {
            var result = this.unit.prods.GetAll();

            return new HandlerResult<List<Product>>(result);
        }
    }
}
