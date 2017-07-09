using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class BeaconController : Controller
    {
        public ActionResult Index()
        {
            IBeaconRepository db = new BeaconRepository();
            var list = db.GetAll().ToList<Beacon>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Beacon model)
        {
            IBeaconRepository db = new BeaconRepository();
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
            IBeaconRepository db = new BeaconRepository();
            Beacon obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, Beacon newObject)
        {
            IBeaconRepository db = new BeaconRepository();
            Beacon currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.Beacon_BusStop = newObject.Beacon_BusStop;
            currentObj.major = newObject.major;
            currentObj.minor = newObject.minor;
            currentObj.uuid = newObject.uuid;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IBeaconRepository db = new BeaconRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}