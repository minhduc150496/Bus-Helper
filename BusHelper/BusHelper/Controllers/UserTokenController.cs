using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class UserTokenController : Controller
    {
        public ActionResult Index()
        {
            IUserTokenRepository db = new UserTokenRepository();
            var list = db.GetAll().ToList<UserToken>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserToken model)
        {
            IUserTokenRepository db = new UserTokenRepository();
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
            IUserTokenRepository db = new UserTokenRepository();
            UserToken obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, UserToken newObject)
        {
            IUserTokenRepository db = new UserTokenRepository();
            UserToken currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.token = newObject.token;
            currentObj.user_id = newObject.user_id;
            currentObj.created_at = newObject.created_at;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IUserTokenRepository db = new UserTokenRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}