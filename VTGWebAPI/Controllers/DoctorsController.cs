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
    public class DoctorsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/Doctors
        public IEnumerable<DoctorsViewModel> GetDoctors()
        {
            var doctors= db.Doctors.ToArray();
            var docsListViewModel = Mapper.Map<Doctor[], IEnumerable<DoctorsViewModel>>(doctors);
            return docsListViewModel;
        }

        // GET: api/Doctors/5
        [ResponseType(typeof(Doctor))]
        public DoctorsViewModel GetDoctor(int id)
        {
            var  doctor = db.Doctors.Find(id);
           
                var docViewModel = Mapper.Map<Doctor, DoctorsViewModel>(doctor);
                //list of clinics
                var clinicList = db.LinkDoctorPractices.Where(p => p.DoctorId == id).Select(s => s.PracticeId).ToList();
                var clinics = new List<Practice>();
                foreach (var clinicId in clinicList)
                {
                    var clinicDetail = db.Practices.Find(clinicId);
                    clinics.Add(clinicDetail);
                }
             var practiceListViewModel = Mapper.Map<List<Practice>, IEnumerable<PracticesViewModel>>(clinics);
                docViewModel.PracticeList = practiceListViewModel;
                return docViewModel;
           
           
        }

        // PUT: api/Doctors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctor(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }

            db.Entry(doctor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        //Put Clinic for a doc.
        
        [Route("api/Doctors/{id}/Pracices/{clinicId}")]
        public IHttpActionResult postClinicForDoctor(int id, int clinicId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var linkedDocPractice = new LinkDoctorPractice();
            db.LinkDoctorPractices.Add(linkedDocPractice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linkedDocPractice.DoctorId }, linkedDocPractice);
        }

        // POST: api/Doctors
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult PostDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Doctors.Add(doctor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doctor.DoctorId }, doctor);
        }

        // DELETE: api/Doctors/5
        [ResponseType(typeof(Doctor))]
        public string DeleteDoctor(int id)
        {
            try
            {
                Doctor doctor = db.Doctors.Find(id);
                if (doctor == null)
                {
                    return "Not Dound";
                }

                db.Doctors.Remove(doctor);
                db.SaveChanges();

                return "success";
                //(doctor);
            }
            catch(Exception e)
            {
                return e.InnerException.ToString();
            }
           
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorExists(int id)
        {
            return db.Doctors.Count(e => e.DoctorId == id) > 0;
        }
    }
}