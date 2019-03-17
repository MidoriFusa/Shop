using DataLayer;
using Shop.BuisnessLayer.Dtos;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public class GetPlaceByIdHandler : BaseCommandHandler<int, PlaceDto>
    {

        public GetPlaceByIdHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<PlaceDto> Execute(int command)
        {
            var result = this.UnitOfWork.Places.GetByid(command);


            if (result == null)
            {
                return new HandlerResult<PlaceDto>(new NotFoundError($"not found with id{command}"));
            }
            return new HandlerResult<PlaceDto>(result);
        }
    }
}
