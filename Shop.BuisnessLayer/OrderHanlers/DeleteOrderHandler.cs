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
     public class DeleteOrderHandler: BaseCommandHandler<int,int>
    {
        public DeleteOrderHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<int> Execute(int command)
        {
            var result = this.UnitOfWork.orders.GetByid(command);

            if (result==null)
            {
                return new HandlerResult<int>(new NotFoundError());
            }

            this.UnitOfWork.orders.Delete(command);
            this.UnitOfWork.Save();
            return new HandlerResult<int>(0);

        }
    }
}
