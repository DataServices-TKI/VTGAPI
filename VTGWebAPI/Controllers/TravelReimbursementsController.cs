using AutoMapper;
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
using VTGWebAPI.ViewModels;

namespace VTGWebAPI.Controllers
{
    public class TravelReimbursementsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/TravelReimbursements
        public IQueryable<TravelReimbursement> GetTravelReimbursements()
        {
            return db.TravelReimbursements;
        }

        // GET: api/TravelReimbursements/5
        [ResponseType(typeof(TravelReimbursement))]
        public TravelReimbursementViewModel GetTravelReimbursement(int id)
        {
            TravelReimbursement travelReimbursement = db.TravelReimbursements.Find(id);
            if (travelReimbursement == null)
            {
                return null;
            }
            var travelReimbursementVM = Mapper.Map<TravelReimbursement, TravelReimbursementViewModel>(travelReimbursement);
            return travelReimbursementVM;
        }

        // PUT: api/TravelReimbursements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTravelReimbursement(int id, TravelReimbursement travelReimbursement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travelReimbursement.TravelReimbursementId)
            {
                return BadRequest();
            }

            db.Entry(travelReimbursement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelReimbursementExists(id))
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

        // POST: api/TravelReimbursements
        [ResponseType(typeof(TravelReimbursement))]
        public IHttpActionResult PostTravelReimbursement(TravelReimbursement travelReimbursement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TravelReimbursements.Add(travelReimbursement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = travelReimbursement.TravelReimbursementId }, travelReimbursement);
        }

        // DELETE: api/TravelReimbursements/5
        [ResponseType(typeof(TravelReimbursement))]
        public IHttpActionResult DeleteTravelReimbursement(int id)
        {
            TravelReimbursement travelReimbursement = db.TravelReimbursements.Find(id);
            if (travelReimbursement == null)
            {
                return NotFound();
            }

            db.TravelReimbursements.Remove(travelReimbursement);
            db.SaveChanges();

            return Ok(travelReimbursement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravelReimbursementExists(int id)
        {
            return db.TravelReimbursements.Count(e => e.TravelReimbursementId == id) > 0;
        }
    }
}