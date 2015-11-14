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
using Dashboard.Web.Models;

namespace Dashboard.Web.Controllers
{
    public class DashboardDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DashboardData
        public IQueryable<DashboardData> GetDashboardData()
        {
            return db.DashboardData;
        }

        // GET: api/DashboardData/5
        [ResponseType(typeof(DashboardData))]
        public IHttpActionResult GetDashboardData(string id)
        {
            DashboardData dashboardData = db.DashboardData.Find(id);
            if (dashboardData == null)
            {
                return NotFound();
            }

            return Ok(dashboardData);
        }

        // PUT: api/DashboardData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDashboardData(string id, DashboardData dashboardData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dashboardData.Id)
            {
                return BadRequest();
            }

            db.Entry(dashboardData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardDataExists(id))
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

        // POST: api/DashboardData
        [ResponseType(typeof(DashboardData))]
        public IHttpActionResult PostDashboardData(DashboardData dashboardData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DashboardData.Add(dashboardData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DashboardDataExists(dashboardData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dashboardData.Id }, dashboardData);
        }

        // DELETE: api/DashboardData/5
        [ResponseType(typeof(DashboardData))]
        public IHttpActionResult DeleteDashboardData(string id)
        {
            DashboardData dashboardData = db.DashboardData.Find(id);
            if (dashboardData == null)
            {
                return NotFound();
            }

            db.DashboardData.Remove(dashboardData);
            db.SaveChanges();

            return Ok(dashboardData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DashboardDataExists(string id)
        {
            return db.DashboardData.Count(e => e.Id == id) > 0;
        }
    }
}