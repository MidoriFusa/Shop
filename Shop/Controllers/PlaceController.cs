using DataLayer;
using Shop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class PlaceController : Controller
    {

        UnitOfWork unitOfWork;

        public PlaceController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {

            unitOfWork.Places.GetAll();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Place item)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Places.Create(item);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(item);
        }


        public ActionResult Edit (int id)
        {
            Place place = unitOfWork.Places.GetByid(id);
            if (place==null)
            {
                return HttpNotFound();
            }
            return View(place);
        }
        [HttpPost]

        public ActionResult Edit(Place item)
        {
            if (ModelState.IsValid)
            {

                unitOfWork.Places.Update(item);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(item);

        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Places.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}