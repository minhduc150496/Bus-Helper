using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class BusInfoController : Controller
    {
        public ActionResult Index()
        {
            IBusInfoRepository db = new BusInfoRepository();
            var list = db.GetAll().ToList<BusInfo>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BusInfo model)
        {
            IBusInfoRepository db = new BusInfoRepository();
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
            IBusInfoRepository db = new BusInfoRepository();
            BusInfo obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, BusInfo newObject)
        {
            IBusInfoRepository db = new BusInfoRepository();
            BusInfo currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.BusInfo_BusStop = newObject.BusInfo_BusStop;
            currentObj.BusInfo_Vehicle = newObject.BusInfo_Vehicle;
            currentObj.number = newObject.number;
            currentObj.start_time = newObject.start_time;
            currentObj.end_time = newObject.end_time;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IBusInfoRepository db = new BusInfoRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}