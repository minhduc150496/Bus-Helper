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
            IBeacon_BusStopRepository dbMapping = new Beacon_BusStopRepository();
            var list = dbMapping.GetAll().ToList<Beacon_BusStop>();

            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            IBeaconRepository dbBeacon = new BeaconRepository();
            var beacons = dbBeacon.GetAll().ToList<Beacon>();
            ViewBag.Beacons = beacons;
            IBusStopRepository dbBusStop = new BusStopRepository();
            var busStops = dbBusStop.GetAll().ToList<BusStop>();
            ViewBag.BusStops = busStops;
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
            IBeaconRepository dbBeacon = new BeaconRepository();
            var beacons = dbBeacon.GetAll().ToList<Beacon>();
            ViewBag.Beacons = beacons;
            IBusStopRepository dbBusStop = new BusStopRepository();
            var busStops = dbBusStop.GetAll().ToList<BusStop>();
            ViewBag.BusStops = busStops;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, Beacon_BusStop newObject)
        {
            IBeacon_BusStopRepository db = new Beacon_BusStopRepository();
            Beacon_BusStop currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.beacon_id = newObject.beacon_id;
            currentObj.bus_stop_id = newObject.bus_stop_id;
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