using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public class GetPlaceByIdHandler : BaseCommandHandler<int, Place>
    {

        public GetPlaceByIdHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<Place> Execute(int command)
        {
            var result = this.UnitOfWork.Places.GetByid(command);


            if (result == null)
            {
                return new HandlerResult<int>(new NotFoundError($"not found with id{command}"));
            }
            return new HandlerResult<Place>(result);
        }
    }
}
