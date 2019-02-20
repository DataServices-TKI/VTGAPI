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
using VTGWebAPI.App_Data;

namespace VTGWebAPI.Controllers
{
    public class BodySystemsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/BodySystems
        public IQueryable<BodySystem> GetBodySystems()
        {
            return db.BodySystems;
        }

        // GET: api/BodySystems/5
        [ResponseType(typeof(BodySystem))]
        public IHttpActionResult GetBodySystem(int id)
        {
            BodySystem bodySystem = db.BodySystems.Find(id);
            if (bodySystem == null)
            {
                return NotFound();
            }

            return Ok(bodySystem);
        }

        // PUT: api/BodySystems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBodySystem(int id, BodySystem bodySystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bodySystem.BodySystemId)
            {
                return BadRequest();
            }

            db.Entry(bodySystem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodySystemExists(id))
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

        // POST: api/BodySystems
        [ResponseType(typeof(BodySystem))]
        public IHttpActionResult PostBodySystem(BodySystem bodySystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BodySystems.Add(bodySystem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bodySystem.BodySystemId }, bodySystem);
        }

        // DELETE: api/BodySystems/5
        [ResponseType(typeof(BodySystem))]
        public IHttpActionResult DeleteBodySystem(int id)
        {
            BodySystem bodySystem = db.BodySystems.Find(id);
            if (bodySystem == null)
            {
                return NotFound();
            }

            db.BodySystems.Remove(bodySystem);
            db.SaveChanges();

            return Ok(bodySystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BodySystemExists(int id)
        {
            return db.BodySystems.Count(e => e.BodySystemId == id) > 0;
        }
    }
}