using DataLayer;
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Common.Errors;
using System.Linq;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public class GetPlaceByIdHandler : BaseCommandHandler<int, PlaceDto>
    {

        public GetPlaceByIdHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<PlaceDto> Execute(int command)
        {
            var result = this.UnitOfWork.Places.GetAll().Where(e => e.PlaceId == command).Select(e => new PlaceDto { Id = e.PlaceId, Name = e.PlaceName, products = e.products }).FirstOrDefault();


            if (result == null)
            {
                return new HandlerResult<PlaceDto>(new NotFoundError());
            }
            return new HandlerResult<PlaceDto>(result);
        }
    }
}
