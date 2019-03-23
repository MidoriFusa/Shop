using DataLayer;
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.ProductHandler
{
    public class GetProductsHandler : BaseCommandHandler<List<ProductDto>>
    {


        public GetProductsHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }




        public override HandlerResult<List<ProductDto>> Execute()
        {
            var result = this.UnitOfWork.prods.GetAll().Select(e => new ProductDto { Id = e.ProductId, Height = e.Height, Length = e.Length, Name = e.ProductName, Width = e.Width, placeDtos = e.places }).ToList();

            return new HandlerResult<List<ProductDto>>(result);
        }
    }
}
