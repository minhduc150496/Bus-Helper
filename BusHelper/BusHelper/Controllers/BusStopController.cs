using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class BusStopController : Controller
    {
        public ActionResult Index()
        {
            IBusStopRepository db = new BusStopRepository();
            var list = db.GetAll().ToList<BusStop>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BusStop model)
        {
            IBusStopRepository db = new BusStopRepository();
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
            IBusStopRepository db = new BusStopRepository();
            BusStop obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, BusStop newObject)
        {
            IBusStopRepository db = new BusStopRepository();
            BusStop currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.latitude = newObject.latitude;
            currentObj.longitude = newObject.longitude;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IBusStopRepository db = new BusStopRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}