using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
//using System.Web.Mvc;
using AutoMapper;
using DataLayer;
using Shop.BuisnessLayer;
using Shop.BuisnessLayer.Commands;
using Shop.BuisnessLayer.Dtos;
using Shop.BuisnessLayer.ProductHandler;
using Shop.Models.Database;

namespace Shop.Controllers
{

    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(List<ProductDto>))]
        public IHttpActionResult GetProducts() => this.RunHandler<GetProductsHandler, List<ProductDto>>();



        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ProductDto))]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult GetPRoduct(int id) => this.RunHandler<GetProductByIdHandler,int,ProductDto>(id);




        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Product))]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult DeletePRoduct(int id) => this.RunHandler<DeleteProductHandler, int, int>(id);



        [Route("{id}")]
        [HttpPut, HttpPost]
        [ResponseType(typeof (ProductDto))]
        [ResponseType(typeof(NotFoundError))]
       public IHttpActionResult CreateProduct(CreateProductDto model)
        {
            var command = Mapper.Map<CreateProductCommand>(model);
            return this.RunHandler<CreateProductHandler, CreateProductCommand, ProductDto>(command);
        }


        //#region mvcapi 
        //UnitOfWork unitofwork;

        //public ProductController()
        //{
        //    unitofwork = new UnitOfWork();
        //}
        //public ActionResult Index()
        //{
        //    var products = unitofwork.prods.GetAll();

        //    return View();
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Product item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        unitofwork.prods.Create(item);
        //        unitofwork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);

        //}


        //public ActionResult Edit(int id)
        //{
        //    Product item = unitofwork.prods.GetByid(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}


        //[HttpPost]
        //public ActionResult Edit(Product item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        unitofwork.prods.Update(item);
        //        unitofwork.Save();
        //        return RedirectToAction("Index");

        //    }
        //    return View(item);
        //}



        //public ActionResult Delete(int id)
        //{
        //    unitofwork.prods.Delete(id);
        //    unitofwork.Save();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    unitofwork.Dispose();
        //    base.Dispose(disposing);
        //}

        //#endregion
    }
}
