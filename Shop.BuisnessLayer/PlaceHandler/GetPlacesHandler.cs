using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.PlaceHandler
{
    public  class GetPlacesHandler:BaseHandler<List<Place>>
    {

        public GetPlacesHandler(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public override HandlerResult<List<Place>> Execute()
        {
            var result = this.UnitOfWork.Places.GetAll().ToList();
            return new HandlerResult<List<Place>>(result);
        }
    }
}
