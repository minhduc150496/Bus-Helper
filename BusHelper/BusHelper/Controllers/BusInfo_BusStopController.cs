using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;


namespace BusHelper.Controllers
{
    public class BusInfo_BusStopController : Controller
    {
        public ActionResult Index()
        {
            IBusInfo_BusStopRepository db = new BusInfo_BusStopRepository();
            var list = db.GetAll().ToList<BusInfo_BusStop>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            IBusInfoRepository dbBusInfo = new BusInfoRepository();
            var busInfos = dbBusInfo.GetAll().ToList<BusInfo>();
            ViewBag.BusInfos = busInfos;
            IBusStopRepository dbBusStop = new BusStopRepository();
            var busStops = dbBusStop.GetAll().ToList<BusStop>();
            ViewBag.BusStops = busStops;
            return View();
        }

        [HttpPost]
        public ActionResult Add(BusInfo_BusStop model)
        {
            IBusInfo_BusStopRepository db = new BusInfo_BusStopRepository();
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
            IBusInfo_BusStopRepository db = new BusInfo_BusStopRepository();
            BusInfo_BusStop obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            IBusInfoRepository dbBusInfo = new BusInfoRepository();
            var busInfos = dbBusInfo.GetAll().ToList<BusInfo>();
            ViewBag.BusInfos = busInfos;
            IBusStopRepository dbBusStop = new BusStopRepository();
            var busStops = dbBusStop.GetAll().ToList<BusStop>();
            ViewBag.BusStops = busStops;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, BusInfo_BusStop newObject)
        {
            IBusInfo_BusStopRepository db = new BusInfo_BusStopRepository();
            BusInfo_BusStop currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.bus_info_id = newObject.bus_info_id;
            currentObj.bus_stop_id = newObject.bus_stop_id;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IBusInfo_BusStopRepository db = new BusInfo_BusStopRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}