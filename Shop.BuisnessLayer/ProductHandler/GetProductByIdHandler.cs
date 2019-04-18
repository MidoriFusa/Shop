using Shop.DataLayer;
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Common.Errors;
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

            var result = this.UnitOfWork.prods.GetAll().Where(e=>e.Id==command).Select(e=>new ProductDto { Id=e.Id, Height=e.Height, Name=e.Name,Length=e.Length, Width=e.Width, BuyPrice=e.BuyPrice,SellPrice=e.SellPrice}).SingleOrDefault();


            if (result== null)
            {
                return new HandlerResult<ProductDto>(new NotFoundError($"not found with id{command}"));
            }
            return new HandlerResult<ProductDto>(result); 
        }
    }
}
