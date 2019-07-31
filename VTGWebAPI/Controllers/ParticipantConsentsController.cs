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
    public class ParticipantConsentsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/ParticipantConsents
        public IEnumerable<ParticipantConsentViewModel> GetParticipantConsents()
        {
           
            var participantConsentList= db.ParticipantConsents.ToArray();
            var participantConsentListVM = Mapper.Map<ParticipantConsent[], IEnumerable<ParticipantConsentViewModel>>(participantConsentList);

            return participantConsentListVM.OrderBy(s=>s.ProcessingStatusCode);
        }

        // GET: api/ParticipantConsents/5
        [ResponseType(typeof(ParticipantConsent))]
        public IHttpActionResult GetParticipantConsent(int id)
        {
            ParticipantConsent participantConsent = db.ParticipantConsents.Find(id);
            if (participantConsent == null)
            {
                return NotFound();
            }

            return Ok(participantConsent);
        }

        // PUT: api/ParticipantConsents/5
        //[ResponseType(typeof(void))]
       // [Route("api/ParticipantConsents/{id}")]
        public IHttpActionResult PutParticipantConsent(int id, ParticipantConsent participantConsent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantConsent.RowId)
            {
                return BadRequest();
            }

            db.Entry(participantConsent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantConsentExists(id))
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

        // POST: api/ParticipantConsents
        [ResponseType(typeof(ParticipantConsent))]
        public IHttpActionResult PostParticipantConsent(ParticipantConsent participantConsent)
        {
            participantConsent.ProcessingStatusCode = 2;
            participantConsent.DateConsented = DateTime.Now;
            participantConsent.ModifiedDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParticipantConsents.Add(participantConsent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participantConsent.RowId }, participantConsent);
        }

        // DELETE: api/ParticipantConsents/5
        [ResponseType(typeof(ParticipantConsent))]
        public IHttpActionResult DeleteParticipantConsent(int id)
        {
            ParticipantConsent participantConsent = db.ParticipantConsents.Find(id);
            if (participantConsent == null)
            {
                return NotFound();
            }

            db.ParticipantConsents.Remove(participantConsent);
            db.SaveChanges();

            return Ok(participantConsent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantConsentExists(int id)
        {
            return db.ParticipantConsents.Count(e => e.RowId == id) > 0;
        }
    }
}