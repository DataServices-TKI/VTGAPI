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
    public class LinkDoctorPracticesController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/LinkDoctorPractices
        public IQueryable<LinkDoctorPractice> GetLinkDoctorPractices()
        {
            return db.LinkDoctorPractices;
        }

        // GET: api/LinkDoctorPractices/5
        [ResponseType(typeof(LinkDoctorPractice))]
        public IHttpActionResult GetLinkDoctorPractice(int id)
        {
            LinkDoctorPractice linkDoctorPractice = db.LinkDoctorPractices.Find(id);
            if (linkDoctorPractice == null)
            {
                return NotFound();
            }

            return Ok(linkDoctorPractice);
        }

        // PUT: api/LinkDoctorPractices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinkDoctorPractice(int id, LinkDoctorPractice linkDoctorPractice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linkDoctorPractice.DoctorPracticeLinkId)
            {
                return BadRequest();
            }

            db.Entry(linkDoctorPractice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkDoctorPracticeExists(id))
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

        // POST: api/LinkDoctorPractices
        [ResponseType(typeof(LinkDoctorPractice))]
        public IHttpActionResult PostLinkDoctorPractice(LinkDoctorPractice linkDoctorPractice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LinkDoctorPractices.Add(linkDoctorPractice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linkDoctorPractice.DoctorPracticeLinkId }, linkDoctorPractice);
        }

        // DELETE: api/LinkDoctorPractices/5
        [ResponseType(typeof(LinkDoctorPractice))]
        public IHttpActionResult DeleteLinkDoctorPractice(int id)
        {
            LinkDoctorPractice linkDoctorPractice = db.LinkDoctorPractices.Find(id);
            if (linkDoctorPractice == null)
            {
                return NotFound();
            }

            db.LinkDoctorPractices.Remove(linkDoctorPractice);
            db.SaveChanges();

            return Ok(linkDoctorPractice);
        }


        // Delete: api/LinkDoctorPractices
        [Route("api/LinkDoctorPractices/{docId}/practice/{practiceId}")]
        public IHttpActionResult DeleteLinkDoctorPractice(int docId, int practiceId)
        {
            LinkDoctorPractice linkDoctorPractice = db.LinkDoctorPractices.Where(l=>l.DoctorId==docId && l.PracticeId==practiceId).FirstOrDefault();
            if (linkDoctorPractice == null)
            {
                return NotFound();
            }

            db.LinkDoctorPractices.Remove(linkDoctorPractice);
            db.SaveChanges();

            return Ok(linkDoctorPractice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinkDoctorPracticeExists(int id)
        {
            return db.LinkDoctorPractices.Count(e => e.DoctorPracticeLinkId == id) > 0;
        }
    }
}