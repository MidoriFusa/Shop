using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.ProductHandler
{
    public class CreateProductHandler : BaseCommandHandler<Product,Product >
    {
        

        public CreateProductHandler(UnitOfWork unitOfWork): base(unitOfWork) { }

        public override HandlerResult<Product> Execute(Product command)
        {
            this.UnitOfWork.prods.Create(command);
            this.UnitOfWork.Save();
            return new HandlerResult<Product>(command);
        }
    }
}
