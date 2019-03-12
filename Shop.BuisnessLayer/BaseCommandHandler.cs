using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer
{
    public abstract class BaseCommandHandler<TResponse,TCommand>
    {
        private UnitOfWork Unit { get; }

        private BaseCommandHandler(UnitOfWork unitOfWork)
        {
            this.Unit = unitOfWork;
        }


        public abstract HandlerResult<TResponse> Execute(TCommand command);

    }
}
