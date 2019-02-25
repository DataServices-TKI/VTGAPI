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
    public class PracticesController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/Practices
        public IEnumerable<PracticesViewModel> GetPractices()
        {
            var practiceList= db.Practices.ToArray();
            var practiveListViewModel = Mapper.Map<Practice[], IEnumerable<PracticesViewModel>>(practiceList);   

            return practiveListViewModel;
        }

        // GET: api/Practices/5
        [ResponseType(typeof(Practice))]
        public PracticesViewModel GetPractice(int id)
        {
            var practice = db.Practices.Find(id);
            var practiveViewModel = Mapper.Map<Practice, PracticesViewModel>(practice);

            //list of Docs
            var docList = db.LinkDoctorPractices.Where(p => p.PracticeId == id).Select(s=>s.DoctorId).ToList();
            var docs = new List<Doctor>();

            foreach(var docId in docList)
            {
                var docDetail = db.Doctors.Find(docId);
                docs.Add(docDetail);
            }

            var docsViewModel = Mapper.Map<List<Doctor>, IEnumerable<DoctorsViewModel>>(docs);


            practiveViewModel.DoctorsList = docsViewModel;

            return practiveViewModel;
        }


        // PUT: api/Practices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPractice(int id, Practice practice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != practice.PracticeId)
            {
                return BadRequest();
            }

            db.Entry(practice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracticeExists(id))
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

        // POST: api/Practices
        [ResponseType(typeof(Practice))]
        public IHttpActionResult PostPractice(Practice practice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Practices.Add(practice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = practice.PracticeId }, practice);
        }



        // DELETE: api/Practices/5
        [ResponseType(typeof(Practice))]
        public IHttpActionResult DeletePractice(int id)
        {
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return NotFound();
            }

            db.Practices.Remove(practice);
            db.SaveChanges();

            return Ok(practice);
        }
        


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PracticeExists(int id)
        {
            return db.Practices.Count(e => e.PracticeId == id) > 0;
        }
    }
}