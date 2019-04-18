using Shop.BuisnessLayer.Commands;
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Common.Errors;
using Shop.DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.OrderHanlers
{
    public class CreateOrderHandler:BaseCommandHandler<CreateOderCommand,GetOrderDto>
    {
        public CreateOrderHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<GetOrderDto> Execute(CreateOderCommand command)
        {

            Order order;
            if (command.Id.GetValueOrDefault() != 0)
            {
                order = this.UnitOfWork.orders.GetAll().Include(e => e.OrderPuncts).Include(e => e.OrderPuncts.Select(l => l.Product)).SingleOrDefault(e => e.Id == command.Id);
            }    
            else
            {
                order = new Order { OrderPuncts =  new List<OrderPunct>(), CreatedDate=DateTime.UtcNow};
            }
            if (order == null)
            {
                return new HandlerResult<GetOrderDto>(new NotFoundError());
            }

            order.Id = command.Id.GetValueOrDefault();
            order.Number = command.Name;
           

            this.UpdateOrderPunct(order, command.Orderpuncts);

            if (command.Id.GetValueOrDefault()==0)
            {

                this.UnitOfWork.orders.Create(order);
            }
            else
            {
                this.UnitOfWork.orders.Update(order);
            }

            this.UnitOfWork.Save();

            var handler = new GetOrderByIdHandler(this.UnitOfWork);
            var result = handler.Execute(order.Id);
            return result;


        }



        private void UpdateOrderPunct(Order order, List<CreateOrderPunctCommand> orderPunctDtos)
        {

            order.OrderPuncts.GroupJoin(orderPunctDtos, e => e.Id, e => e.Id, (a, b) => new { a, b })
                .SelectMany(e => e.b.DefaultIfEmpty(), (a, b) => new { From = a.a, To = b })
                .ForEach(
                e =>
                {
                    if (e.To == null)
                    {
                        this.UnitOfWork.orderpuncts.Delete(e.From.Id);
                    }
                    else
                    {
                        e.From.Count = e.To.Count;

                        this.UnitOfWork.orderpuncts.Update(e.From);
                    }
                }

                );




            orderPunctDtos.GroupJoin(order.OrderPuncts, e => e.Id, e => e.Id, (a, b) => new { b, a })
               .SelectMany(e => e.b.DefaultIfEmpty(), (a, b) => new { From = a.a, To = b })
               .Where(e => e.To == null)
               .Select(
                e => new OrderPunct
                {
                    Id = e.From.Id.GetValueOrDefault(),
                    Count = e.From.Count,
                    ProductId = e.From.ProductId,
                    Order=order,
                    OrderId=order.Id,

                }

                )
                .ForEach(

                e => this.UnitOfWork.orderpuncts.Create(e)
                );
               
                
               

        }
    }
}
