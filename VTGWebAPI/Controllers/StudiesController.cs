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
    public class StudiesController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/Studies
        public IEnumerable<StudyViewModel> GetStudies()
        {
            var studyListViewModel = new List<StudyViewModel>();
            var mapper = new StudyMapper();

            var studyList = db.GetStudyList();

            foreach (var s in studyList)
                {
                    studyListViewModel.Add(mapper.GetStudyViewModel(s));
                }
            return studyListViewModel;


        }

        // GET: api/Studies/5
        [ResponseType(typeof(Study))]
        public StudyViewModel GetStudy(int id)
        {
            var study = db.GetStudyDetailById(id).FirstOrDefault();
            var studyViewModel = Mapper.Map<StudyDetailById, StudyViewModel>(study);
            if (!string.IsNullOrEmpty(studyViewModel.SubjectMinAgeInequality))
            {
                if (studyViewModel.SubjectMinAgeInequality == "GTOET")
                {
                    studyViewModel.GreaterThanEquals = true;
                }
                else if (studyViewModel.SubjectMinAgeInequality == "GT")
                {
                    studyViewModel.GreaterThan = true;
                }                  
                              
            }

            if (studyViewModel.SubjectMinAgeInYears.HasValue)
            {
                if (studyViewModel.SubjectMinAgeInYears.Value > 1)
                {
                    studyViewModel.MinYear = (int)(studyViewModel.SubjectMinAgeInYears.Value);
                    var remainder = (studyViewModel.SubjectMinAgeInYears.Value % 1);
                    studyViewModel.MinMonth = (int)(remainder * 12);
                }
                else
                {
                    studyViewModel.MinYear = 0;
                    var remainder = studyViewModel.SubjectMinAgeInYears.Value;
                    studyViewModel.MinMonth = (int)(remainder * 12);
                }
            
               
            }

            if (!string.IsNullOrEmpty(studyViewModel.SubjectMaxAgeInequality))
            {
                if (studyViewModel.SubjectMinAgeInequality == "LTOET")
                {
                    studyViewModel.LessThanEquals = true;
                }
                else if (studyViewModel.SubjectMaxAgeInequality == "LT")
                {
                    studyViewModel.LessThan = true;
                }
            }
            if (studyViewModel.SubjectMaxAgeInYears.HasValue)
            {
                if (studyViewModel.SubjectMaxAgeInYears.Value > 1)
                {
                    studyViewModel.MaxYear = (int)(studyViewModel.SubjectMaxAgeInYears.Value);
                    var remainder = (studyViewModel.SubjectMaxAgeInYears.Value % 1);
                    studyViewModel.MaxMonth = (int)(remainder * 12);
                }
                else
                {
                    studyViewModel.MaxYear = 0;
                    var remainder = studyViewModel.SubjectMaxAgeInYears.Value;
                    studyViewModel.MaxMonth = (int)(remainder * 12);
                }

            }


            return studyViewModel;
        }

        // PUT: api/Studies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudy(int id, Study study)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != study.StudyId)
            {
                return BadRequest();
            }

            db.Entry(study).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyExists(id))
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

        // POST: api/Studies
        [ResponseType(typeof(Study))]
        public IHttpActionResult PostStudy(Study study)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Studies.Add(study);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = study.StudyId }, study);
        }

        // DELETE: api/Studies/5
        [ResponseType(typeof(Study))]
        public IHttpActionResult DeleteStudy(int id)
        {
            Study study = db.Studies.Find(id);
            if (study == null)
            {
                return NotFound();
            }

            db.Studies.Remove(study);
            db.SaveChanges();

            return Ok(study);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudyExists(int id)
        {
            return db.Studies.Count(e => e.StudyId == id) > 0;
        }
    }
}