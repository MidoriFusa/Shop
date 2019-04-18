using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Common.Errors;
using Shop.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.OrderHanlers
{
    public class GetOrderByIdHandler : BaseCommandHandler<int, GetOrderDto>
    {

        public GetOrderByIdHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }
        public override HandlerResult<GetOrderDto> Execute(int command)
        {
            var result = this.UnitOfWork.orders.GetAll().Where(e => e.Id == command)
                .Select(e => new GetOrderDto
                {
                    Id = e.Id,
                    Name = e.Number,
                    Orderpuncts = e.OrderPuncts.Select(l => new OrderPunctDto
                    {
                        Id = l.Id,
                        ProductId = l.ProductId,
                        ProductName = l.Product.Name,
                        SellPrice = l.Product.SellPrice,
                        Count = l.Count,
                    }).ToList(),
                }).FirstOrDefault();
           
            if (result==null)
            {
                return new HandlerResult<GetOrderDto>(new NotFoundError($"not found order with id {command}"));
            }

            return new HandlerResult<GetOrderDto>(result);
            
        }
    }
}
