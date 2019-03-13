using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer
{
    public abstract class BaseCommandHandler<TCommand,TResponse>
    {
        protected UnitOfWork UnitOfWork { get; }

        protected BaseCommandHandler(UnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }


        public abstract HandlerResult<TResponse> Execute(TCommand command);

    }
}
