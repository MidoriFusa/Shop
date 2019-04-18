using Shop.DataLayer;
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
            var result = this.UnitOfWork.prods.GetAll().Select(e => new ProductDto { Id = e.Id, Height = e.Height, Length = e.Length, Name =e.Name, Width = e.Width , BuyPrice=e.BuyPrice,SellPrice=e.SellPrice}).ToList();

            return new HandlerResult<List<ProductDto>>(result);
        }
    }
}
