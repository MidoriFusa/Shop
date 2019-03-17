using DataLayer;
using Shop.BuisnessLayer.Dtos;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.ProductHandler
{
   public class GetProductByIdHandler:BaseCommandHandler<int,ProductDto>
    {

        public GetProductByIdHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<ProductDto> Execute(int command)
        {
            var result = this.UnitOfWork.prods.GetByid(command);


            if (result== null)
            {
                return new HandlerResult<ProductDto>(new NotFoundError($"not found with id{command}"));
            }
            return new HandlerResult<ProductDto>(result); 
        }
    }
}
