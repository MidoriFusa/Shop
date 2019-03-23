using DataLayer;
using Shop.BuisnessLayer;
using Shop.BuisnessLayer.Dtos;
using Shop.BuisnessLayer.PlaceHandler;
using Shop.Models.Database;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Shop.BuisnessLayer.Commands;
using Shop.Common.Errors;

namespace Shop.Controllers
{

    [RoutePrefix("places")]
    public class PlaceController : BaseApiController
    {


        [Route(" ")]
        [HttpGet]
        [ResponseType(typeof(List<PlaceDto>))]
        public IHttpActionResult GetPlaceList() => this.RunHandler<GetPlacesHandler, List<PlaceDto>>();


        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(PlaceDto))]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult GetPlaceById(int id) => this.RunHandler<GetPlaceByIdHandler, int, PlaceDto>(id);


        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Place))]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult DeletePlace(int id) => this.RunHandler<DeletePlaceHandler, int, int>(id);


        [Route("{id}")]
        [HttpPut, HttpPost]
        [ResponseType(typeof(Place))]
        [ResponseType(typeof(NotFoundError))]
        public IHttpActionResult UpdatePlace(PlaceUpdateDto model)
        {
            var result = Mapper.Map<UpdatePlaceCommand>(model);
            return this.RunHandler<UpdatePlaceHandler, UpdatePlaceCommand, PlaceDto>(result);
        }



        //UnitOfWork unitOfWork;

        //public PlaceController()
        //{
        //    unitOfWork = new UnitOfWork();
        //}
        //public ActionResult Index()
        //{

        //    unitOfWork.Places.GetAll();

        //    return View();
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Place item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        unitOfWork.Places.Create(item);
        //        unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);
        //}


        //public ActionResult Edit (int id)
        //{
        //    Place place = unitOfWork.Places.GetByid(id);
        //    if (place==null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(place);
        //}
        //[HttpPost]

        //public ActionResult Edit(Place item)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        unitOfWork.Places.Update(item);
        //        unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);

        //}

        //public ActionResult Delete(int id)
        //{
        //    unitOfWork.Places.Delete(id);
        //    unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}