using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public class UpdatePlaceHandler:BaseCommandHandler<int , Place>
    {


        public UpdatePlaceHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<Place> Execute(int command)
        {
            var result = this.UnitOfWork.Places.GetByid(command);

            if (result==null)
            {
                return new HandlerResult<Place>(new NotFounErro($"Not found place wtih id {command}"));
            }

            this.UnitOfWork.Places.Update(result);
            this.UnitOfWork.Save();
            return new HandlerResult<Place>(result);

        }
    }
}
