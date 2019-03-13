using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer
{
    public abstract class BaseHandler<TResponse>
    {
        protected UnitOfWork UnitOfWork { get; }


        protected BaseHandler(UnitOfWork unitwork)
        {

            this.UnitOfWork = unitwork;
        }


        public abstract HandlerResult<TResponse> Execute();



    }
}
