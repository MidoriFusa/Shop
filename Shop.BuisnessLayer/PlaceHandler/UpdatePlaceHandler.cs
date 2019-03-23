using DataLayer;
using Shop.BuisnessLayer.Commands;
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Common.Errors;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public class UpdatePlaceHandler:BaseCommandHandler<UpdatePlaceCommand , PlaceDto>
    {


        public UpdatePlaceHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<PlaceDto> Execute(UpdatePlaceCommand command)
        {
            Place entity;

            if (command.PlaceId.GetValueOrDefault()==0)
            {
                entity = new Place();
            }
            else
            {
                entity = this.UnitOfWork.Places.GetByid(command.PlaceId);
            }


            if (entity == null)
            {
                return new HandlerResult<PlaceDto>(new NotFoundError($"Not found region with id {command.PlaceId}"));
            }

            entity.PlaceName = command.PlaceName;
            entity.products = entity.products;

            if (command.PlaceId.GetValueOrDefault() == 0)
            {
                this.UnitOfWork.Places.Create(entity);
            }
            else
            {
                this.UnitOfWork.Places.Update(entity);
            }
            this.UnitOfWork.Save();
            var handler = new GetPlaceByIdHandler(this.UnitOfWork);
            var result = handler.Execute(entity.PlaceId);
            return result;


        }
    }
}
