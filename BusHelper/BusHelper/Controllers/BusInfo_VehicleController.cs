using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class BusInfo_VehicleController : Controller
    {
        public ActionResult Index()
        {
            IBusInfo_VehicleRepository db = new BusInfo_VehicleRepository();
            var list = db.GetAll().ToList<BusInfo_Vehicle>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            IBusInfoRepository dbBusInfo = new BusInfoRepository();
            var busInfos = dbBusInfo.GetAll().ToList<BusInfo>();
            ViewBag.BusInfos = busInfos;
            IVehicleRepository dbVehicle = new VehicleRepository();
            var vehicles = dbVehicle.GetAll().ToList<Vehicle>();
            ViewBag.Vehicles = vehicles;
            return View();
        }

        [HttpPost]
        public ActionResult Add(BusInfo_Vehicle model)
        {
            IBusInfo_VehicleRepository db = new BusInfo_VehicleRepository();
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
            IBusInfo_VehicleRepository db = new BusInfo_VehicleRepository();
            BusInfo_Vehicle obj = db.GetSingle(id);
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
        public ActionResult Update(int id, BusInfo_Vehicle newObject)
        {
            IBusInfo_VehicleRepository db = new BusInfo_VehicleRepository();
            BusInfo_Vehicle currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.bus_info_id = newObject.bus_info_id;
            currentObj.vehicle_id = newObject.vehicle_id;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IBusInfo_VehicleRepository db = new BusInfo_VehicleRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}