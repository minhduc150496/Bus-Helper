using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class Beacon_BusStopController : Controller
    {
        public ActionResult Index()
        {
            IBeacon_BusStopRepository db = new Beacon_BusStopRepository();
            var list = db.GetAll().ToList<Beacon_BusStop>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Beacon_BusStop model)
        {
            IBeacon_BusStopRepository db = new Beacon_BusStopRepository();
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
            IBeacon_BusStopRepository db = new Beacon_BusStopRepository();
            Beacon_BusStop obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, Beacon_BusStop newObject)
        {
            IBeacon_BusStopRepository db = new Beacon_BusStopRepository();
            Beacon_BusStop currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            // remember to copy fields from newObject to current Obj
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IBeacon_BusStopRepository db = new Beacon_BusStopRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}