using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.ProductHandler
{
   public class DeleteProductHandler : BaseCommandHandler<int, int>

    {


        public DeleteProductHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }
        public override HandlerResult<int> Execute(int command)
        {
            var result = this.UnitOfWork.prods.GetByid(command);
            if (result==null)
            {
                return new HandlerResult<int>(new NotFoundError($"Not found product with id {command}"));
            }


            this.UnitOfWork.prods.Delete(command);
            this.UnitOfWork.Save();
            return new HandlerResult<int>(0);
        }
    }
}
