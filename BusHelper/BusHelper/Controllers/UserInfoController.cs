using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class UserInfoController : Controller
    {
        public ActionResult Index()
        {
            IUserInfoRepository db = new UserInfoRepository();
            var list = db.GetAll().ToList<UserInfo>();
            ViewBag.List = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserInfo model)
        {
            IUserInfoRepository db = new UserInfoRepository();
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
            IUserInfoRepository db = new UserInfoRepository();
            UserInfo obj = db.GetSingle(id);
            ViewBag.Obj = obj;
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, UserInfo newObject)
        {
            IUserInfoRepository db = new UserInfoRepository();
            UserInfo currentObj = db.GetSingle(id);
            db.Edit(currentObj);
            currentObj.email = newObject.email;
            currentObj.password = newObject.password;
            currentObj.role = newObject.role;
            currentObj.username = newObject.username;
            db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IUserInfoRepository db = new UserInfoRepository();
            db.Delete(db.GetSingle(id));
            db.Save();
            return RedirectToAction("Index");
        }

    }
}