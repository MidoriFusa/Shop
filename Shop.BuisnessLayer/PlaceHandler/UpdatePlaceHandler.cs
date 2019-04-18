using Shop.DataLayer;
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

            if (command.Id.GetValueOrDefault()==0)
            {
                entity = new Place();
            }
            else
            {
                entity = this.UnitOfWork.Places.GetByid(command.Id);
            }


            if (entity == null)
            {
                return new HandlerResult<PlaceDto>(new NotFoundError($"Not found Place with id {command.Id}"));
            }

            entity.Name = command.Name;
            

            if (command.Id.GetValueOrDefault() == 0)
            {
                this.UnitOfWork.Places.Create(entity);
            }
            else
            {
                this.UnitOfWork.Places.Update(entity);
            }
            this.UnitOfWork.Save();
            var handler = new GetPlaceByIdHandler(this.UnitOfWork);
            var result = handler.Execute(entity.Id);
            return result;


        }
    }
}
