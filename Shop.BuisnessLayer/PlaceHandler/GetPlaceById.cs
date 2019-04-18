
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Common.Errors;
using Shop.DataLayer;
using System.Linq;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public class GetPlaceByIdHandler : BaseCommandHandler<int, PlaceDto>
    {

        public GetPlaceByIdHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<PlaceDto> Execute(int command)
        {
            var result = this.UnitOfWork.Places.GetAll().Where(e => e.Id == command).Select(e => new PlaceDto { Id = e.Id, Name = e.Name }).FirstOrDefault();


            if (result == null)
            {
                return new HandlerResult<PlaceDto>(new NotFoundError());
            }
            return new HandlerResult<PlaceDto>(result);
        }
    }
}
