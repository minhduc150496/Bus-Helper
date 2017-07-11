using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusHelperDAL;

namespace BusHelperAPI.Controllers
{
    public class BusStopsAPIController : ApiController
    {
        private BusHelperEntities db = new BusHelperEntities();

        // GET: api/BusStops
        public IQueryable<BusStop> GetBusStops()
        {
            return db.BusStops;
        }

        // GET: api/BusStops/5
        [ResponseType(typeof(BusStop))]
        public IHttpActionResult GetBusStop(int id)
        {
            BusStop busStop = db.BusStops.Find(id);
            if (busStop == null)
            {
                return NotFound();
            }
            return Ok(busStop.name);
        }

        // PUT: api/BusStops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusStop(int id, BusStop busStop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != busStop.id)
            {
                return BadRequest();
            }

            db.Entry(busStop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusStopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BusStops
        [ResponseType(typeof(BusStop))]
        public IHttpActionResult PostBusStop(BusStop busStop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusStops.Add(busStop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = busStop.id }, busStop);
        }

        // DELETE: api/BusStops/5
        [ResponseType(typeof(BusStop))]
        public IHttpActionResult DeleteBusStop(int id)
        {
            BusStop busStop = db.BusStops.Find(id);
            if (busStop == null)
            {
                return NotFound();
            }

            db.BusStops.Remove(busStop);
            db.SaveChanges();

            return Ok(busStop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusStopExists(int id)
        {
            return db.BusStops.Count(e => e.id == id) > 0;
        }
    }
}
