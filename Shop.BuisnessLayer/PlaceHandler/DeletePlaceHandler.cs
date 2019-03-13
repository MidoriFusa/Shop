using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public class DeletePlaceHandler: BaseCommandHandler<int,int>
    {
        public DeletePlaceHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<int> Execute(int command)
        {
            var result = this.UnitOfWork.Places.GetByid(command);

            if (result == null)
            {
                return new HandlerResult<int>(new NoFoundError($"No found with id {command}"));
            }

            this.UnitOfWork.Places.Delete(command);
            this.UnitOfWork.Save();
            return new HandlerResult<int>(0);

        }
    }
}
