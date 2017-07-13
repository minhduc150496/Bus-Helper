using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusHelperDAL.Repository;
using BusHelperDAL;

namespace BusHelperAPI.Controllers
{
    public class BusStopsController : ApiController
    {
        // Get api/UserTokens
        public IEnumerable<BusStop> GetBusStops()
        {

            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

        //    headers.Add

            IBusStopRepository db = new BusStopRepository();
            var list = db.GetAll().ToList<BusStop>();
            return list;
        }
    }
}
