using AutoMapper;
using Shop.BuisnessLayer.Commands;
using Shop.BuisnessLayer.Dtos;
using Shop.BuisnessLayer.OrderHanlers;
using Shop.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;


namespace Shop.Controllers
{

    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(List<GetOrderDto>))]
        public IHttpActionResult GetOrders() => this.RunHandler<GetOrdersHandler, List<GetOrdersDto>>();


        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(GetOrderDto))]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult  GetOrderByID(int id) => this.RunHandler<GetOrderByIdHandler, int, GetOrderDto>(id);

        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult DeleteProduct(int id) => this.RunHandler<DeleteOrderHandler, int, int>(id);



        [Route("")]
        [HttpPost,HttpPut]
        [ResponseType(typeof(GetOrderDto))]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult UpdateOrder(CreateOrderDto model)
        {
            var command = Mapper.Map<CreateOderCommand>(model);
            return this.RunHandler<CreateOrderHandler, CreateOderCommand, GetOrderDto>(command);

        }

    }
}