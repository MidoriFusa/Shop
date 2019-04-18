using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.OrderHanlers
{
    public class GetOrdersHandler : BaseCommandHandler<List<GetOrdersDto>>
    {

        public GetOrdersHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<List<GetOrdersDto>> Execute()
        {
            var result = this.UnitOfWork.orders.GetAll().Select(
                e => new GetOrdersDto
                {
                    Id = e.Id,
                    Name = e.Number,
                    Date = e.CreatedDate,
                    Count = e.OrderPuncts.Count(),
                    SumPrice = e.OrderPuncts.Sum(l=> l.Product.SellPrice * l.Count),
                }).ToList();


            return new HandlerResult<List<GetOrdersDto>>(result);
        }
    }
}
