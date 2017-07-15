using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusHelperDAL;
using BusHelperDAL.Repository;

namespace BusHelper.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            IBeaconRepository dbBeacon = new BeaconRepository();
            var nBeacons = dbBeacon.GetAll().Count();
            ViewBag.nBeacons = nBeacons;
            IBusInfoRepository dbBusInfo = new BusInfoRepository();
            var nBusInfos = dbBusInfo.GetAll().Count();
            ViewBag.nBusInfos = nBusInfos;
            IBusStopRepository dbBusStop = new BusStopRepository();
            var nBusStops = dbBusStop.GetAll().Count();
            ViewBag.nBusStops = nBusStops;
            IVehicleRepository dbVehicle = new VehicleRepository();
            var nVehicles = dbVehicle.GetAll().Count();
            ViewBag.nVehicles = nVehicles;
            IUserInfoRepository dbUser = new UserInfoRepository();
            var nUsers = dbUser.GetAll().Count();
            ViewBag.nUsers = nUsers;
            IUserTokenRepository dbUserToken = new UserTokenRepository();
            var nUserTokens = dbUserToken.GetAll().Count();
            ViewBag.nUserTokens = nUserTokens;
            return View();
        }
    }
}