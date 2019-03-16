using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.ProductHandler
{
    public class GetProductsHandler : BaseCommandHandler<List<Product>>
    {


        public GetProductsHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }




        public override HandlerResult<List<Product>> Execute()
        {
            var result = this.UnitOfWork.prods.GetAll().ToList();
            return new HandlerResult<List<Product>>(result);
        }
    }
}
