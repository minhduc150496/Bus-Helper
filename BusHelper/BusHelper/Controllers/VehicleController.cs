using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class VehicleController : Controller
    {
        public ActionResult Index()
        {
            IVehicleRepository db = new VehicleRepository();
            var list = db.GetAll().ToList<Vehicle>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Vehicle model)
        {
            IVehicleRepository db = new VehicleRepository();
            try {
                db.Add(model);
                db.Save();
            } catch (Exception)
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IVehicleRepository db = new VehicleRepository();
            Vehicle obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, Vehicle newObject)
        {
            IVehicleRepository db = new VehicleRepository();
            Vehicle currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.number = newObject.number;
            currentObj.driver_name = newObject.driver_name;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IVehicleRepository db = new VehicleRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}