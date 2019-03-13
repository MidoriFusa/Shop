using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.ProductHandler
{
   public class GetProductByIdHandler:BaseCommandHandler<int,Product>
    {

        public GetProductByIdHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<Product> Execute(int command)
        {
            var result = this.UnitOfWork.prods.GetByid(command);


            if (result== null)
            {
                return new HandlerResult<Product>(new NotFoundError($"not found with id{command}"));
            }
            return new HandlerResult<Product>(result); 
        }
    }
}
