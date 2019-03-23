using DataLayer;
using Shop.BuisnessLayer.Dtos;
using Shop.Common;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public  class GetPlacesHandler:BaseCommandHandler<List<PlaceDto>>
    {

        public GetPlacesHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<List<PlaceDto>> Execute()
        {
            var result = this.UnitOfWork.Places.GetAll().Select(e => new PlaceDto { Id = e.PlaceId, Name = e.PlaceName, products = e.products }).ToList();
            return new HandlerResult<List<PlaceDto>>(result);
        }
    }
}
