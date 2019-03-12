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
        protected UnitOfWork unit { get; }


        protected BaseHandler(UnitOfWork unitwork)
        {

            this.unit = unitwork;
        }


        public abstract HandlerResult<TResponse> Execute();



    }
}
