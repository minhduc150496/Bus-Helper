using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class HistoryController : Controller
    {
        public ActionResult Index()
        {
            IHistoryRepository db = new HistoryRepository();
            var list = db.GetAll().ToList<History>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(History model)
        {
            IHistoryRepository db = new HistoryRepository();
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
            IHistoryRepository db = new HistoryRepository();
            History obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, History newObject)
        {
            IHistoryRepository db = new HistoryRepository();
            History currentObj = db.GetSingle(id);
            db.Edit(currentObj);

            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IHistoryRepository db = new HistoryRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}