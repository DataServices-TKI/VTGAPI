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
    public class DiagnosesIcdsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/DiagnosesIcds
        public IEnumerable<DiagnosesIcd> GetDiagnosesIcds()
        {
            return db.DiagnosesIcds.ToList();
        }

        // GET: api/DiagnosesIcds/5
        [ResponseType(typeof(DiagnosesIcd))]
        public IHttpActionResult GetDiagnosesIcd(int id)
        {
            DiagnosesIcd diagnosesIcd = db.DiagnosesIcds.Find(id);
            if (diagnosesIcd == null)
            {
                return NotFound();
            }

            return Ok(diagnosesIcd);
        }

        // PUT: api/DiagnosesIcds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiagnosesIcd(int id, DiagnosesIcd diagnosesIcd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diagnosesIcd.DiagnosisId)
            {
                return BadRequest();
            }

            db.Entry(diagnosesIcd).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosesIcdExists(id))
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

        // POST: api/DiagnosesIcds
        [ResponseType(typeof(DiagnosesIcd))]
        public IHttpActionResult PostDiagnosesIcd(DiagnosesIcd diagnosesIcd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DiagnosesIcds.Add(diagnosesIcd);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DiagnosesIcdExists(diagnosesIcd.DiagnosisId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = diagnosesIcd.DiagnosisId }, diagnosesIcd);
        }

        // DELETE: api/DiagnosesIcds/5
        [ResponseType(typeof(DiagnosesIcd))]
        public IHttpActionResult DeleteDiagnosesIcd(int id)
        {
            DiagnosesIcd diagnosesIcd = db.DiagnosesIcds.Find(id);
            if (diagnosesIcd == null)
            {
                return NotFound();
            }

            db.DiagnosesIcds.Remove(diagnosesIcd);
            db.SaveChanges();

            return Ok(diagnosesIcd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiagnosesIcdExists(int id)
        {
            return db.DiagnosesIcds.Count(e => e.DiagnosisId == id) > 0;
        }
    }
}