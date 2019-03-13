using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Shop.Models.Database;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        //[Route("")]
        //[HttpGet]
        //[ResponseType(typeof(List<Product>))]
        //public IHttpActionResult GetProducts() => this.RunHandler<GetProductsHandler, List<Product>>();



        UnitOfWork unitofwork;

        public ProductController()
        {
            unitofwork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var products = unitofwork.prods.GetAll();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

       [HttpPost]
       public ActionResult Create(Product item)
        {
            if (ModelState.IsValid)
            {
                unitofwork.prods.Create(item);
                unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(item);

        }


        public ActionResult Edit(int id)
        {
            Product item = unitofwork.prods.GetByid(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }


        [HttpPost]
        public ActionResult Edit (Product item)
        {
            if (ModelState.IsValid)
            {
                unitofwork.prods.Update(item);
                unitofwork.Save();
                return RedirectToAction("Index");

            }
            return View(item);
        }



        public ActionResult Delete(int id)
        {
            unitofwork.prods.Delete(id);
            unitofwork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitofwork.Dispose();
            base.Dispose(disposing);
        }


    }
}
