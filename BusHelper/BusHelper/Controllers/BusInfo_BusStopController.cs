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
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, BusInfo_BusStop newObject)
        {
            IBusInfo_BusStopRepository db = new BusInfo_BusStopRepository();
            BusInfo_BusStop currentObj = db.GetSingle(id);
            db.Edit(currentObj);
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