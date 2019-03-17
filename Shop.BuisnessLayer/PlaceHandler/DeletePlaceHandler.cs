using DataLayer;

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
                return new HandlerResult<int>(new NotFoundError($"No found with id {command}"));
            }

            this.UnitOfWork.Places.Delete(command);
            this.UnitOfWork.Save();
            return new HandlerResult<int>(0);

        }
    }
}
