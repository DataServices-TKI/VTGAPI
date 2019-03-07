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
    public class LinkSubjectsStudiesController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/LinkSubjectsStudies
        public IQueryable<LinkSubjectsStudy> GetLinkSubjectsStudies()
        {
            return db.LinkSubjectsStudies;
        }

        // GET: api/LinkSubjectsStudies/5
        [ResponseType(typeof(LinkSubjectsStudy))]
        public IHttpActionResult GetLinkSubjectsStudy(int id)
        {
            LinkSubjectsStudy linkSubjectsStudy = db.LinkSubjectsStudies.Find(id);
            if (linkSubjectsStudy == null)
            {
                return NotFound();
            }

            return Ok(linkSubjectsStudy);
        }

        // PUT: api/LinkSubjectsStudies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinkSubjectsStudy(int id, LinkSubjectsStudy linkSubjectsStudy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linkSubjectsStudy.SubjectStudyLinkId)
            {
                return BadRequest();
            }

            db.Entry(linkSubjectsStudy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkSubjectsStudyExists(id))
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

        // POST: api/LinkSubjectsStudies
        [ResponseType(typeof(LinkSubjectsStudy))]
        public IHttpActionResult PostLinkSubjectsStudy(LinkSubjectsStudy linkSubjectsStudy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //check if already exists
            var link = db.LinkSubjectsStudies.Where(l => l.StudyId == linkSubjectsStudy.StudyId && l.PersonId == linkSubjectsStudy.PersonId).ToList();
            if (link.Count==0)
            {

                db.LinkSubjectsStudies.Add(linkSubjectsStudy);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = linkSubjectsStudy.SubjectStudyLinkId }, linkSubjectsStudy);
            }
            return Ok(linkSubjectsStudy);

        }

        // DELETE: api/LinkSubjectsStudies/5
        [ResponseType(typeof(LinkSubjectsStudy))]
        public IHttpActionResult DeleteLinkSubjectsStudy(int id)
        {
            LinkSubjectsStudy linkSubjectsStudy = db.LinkSubjectsStudies.Find(id);
            if (linkSubjectsStudy == null)
            {
                return NotFound();
            }

            db.LinkSubjectsStudies.Remove(linkSubjectsStudy);
            db.SaveChanges();

            return Ok(linkSubjectsStudy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinkSubjectsStudyExists(int id)
        {
            return db.LinkSubjectsStudies.Count(e => e.SubjectStudyLinkId == id) > 0;
        }
    }
}