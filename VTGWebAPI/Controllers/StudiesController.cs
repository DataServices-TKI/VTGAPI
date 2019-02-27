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


        [Route("api/Studies/{studyId}/Consent")]
        public IEnumerable<InformedConsentViewModel> GetConsentList(int studyId)
        {
            #region InformedConsent
            var informedConsents = db.InformedConsents.Where(ic => ic.StudyId == studyId).ToList();
            var informedConsentsViewModel = Mapper.Map<List<InformedConsent>, IEnumerable<InformedConsentViewModel>>(informedConsents);

            #endregion
            return informedConsentsViewModel;
        }

        [Route("api/Studies/{studyId}/Consent/{id}")]
        public InformedConsentViewModel GetConsent(int studyId, int id )
        {    
            #region InformedConsent
            var informedConsent = db.InformedConsents.Where(ic => ic.StudyId == studyId && ic.InformedConsentId==id).FirstOrDefault();
            var informedConsentViewModel = Mapper.Map<InformedConsent,InformedConsentViewModel>(informedConsent);
           
            #endregion
            return informedConsentViewModel;
        }

        [Route("api/Studies/{studyId}/Recruit/{id}")]
        public RecruitmentViewModel GetRecruitment(int studyId, int id)
        {
            #region Recruitment
            var recruit = db.Recruitments.Where(ic => ic.StudyId == studyId && ic.RecruitmentId == id).FirstOrDefault();
            var recruitVM = Mapper.Map<Recruitment, RecruitmentViewModel>(recruit);

            #endregion
            return recruitVM;
        }

        // GET: api/Studies/5
        [ResponseType(typeof(Study))]
        public StudyViewModel GetStudy(int id)
        {
            var study = db.GetStudyDetailById(id).FirstOrDefault();
            var studyViewModel = Mapper.Map<StudyDetailById, StudyViewModel>(study);



            #region SubjectAgeCriteria
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
                if (studyViewModel.SubjectMaxAgeInequality == "LTOET")
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
                    studyViewModel.MaxMonth = (int)(Math.Round(remainder * 12));
                }
                else
                {
                    studyViewModel.MaxYear = 0;
                    var remainder = studyViewModel.SubjectMaxAgeInYears.Value;
                    studyViewModel.MaxMonth = (int)(Math.Round(remainder * 12));
                }

            }
            #endregion


            #region VisitSchedule
            var visitSchedule = db.GetStudyVisitTasks(id).ToArray();
            var visitList=Mapper.Map<StudyVisitTasks[], IEnumerable<VisitScheduleViewModel>> (visitSchedule);          
           
            studyViewModel.VisitList = visitList;
            #endregion

            #region Recruitment
            var recuitment = db.Recruitments.Where(r=>r.StudyId==id).ToArray();
                var recruitmentViewModel = Mapper.Map<Recruitment[], IEnumerable<RecruitmentViewModel>>(recuitment);
                studyViewModel.RecruitmentList = recruitmentViewModel;
            #endregion

            #region InformedConsent
                var informedConsent = db.InformedConsents.Where(ic => ic.StudyId == id).ToArray();
                var informedConsentViewModel = Mapper.Map<InformedConsent[], IEnumerable<InformedConsentViewModel>>(informedConsent);
                studyViewModel.InformedConsentList = informedConsentViewModel;
            #endregion

            #region StaffRoles
                var staff = db.GetStaffRolesForStudy(id).ToArray();
                var staffRolesViewModel = Mapper.Map<StaffRolesForStudy[], IEnumerable<LinkVtgStaffStudyViewModel>>(staff);
                studyViewModel.LinkVtgStaffStudies = staffRolesViewModel;
                #endregion

            return studyViewModel;
        }

        [Route("api/Studies/InformedConsents/{id}")]     
        public IHttpActionResult PutStudyConsent(int id, InformedConsentViewModel informedConsent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != informedConsent.InformedConsentId)
            {
                return BadRequest();
            }

            var consent = Mapper.Map<InformedConsentViewModel, InformedConsent>(informedConsent);

            db.Entry(consent).State = EntityState.Modified;           
            db.SaveChanges();
            
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/Studies/Recruitments/{id}")]
        public IHttpActionResult PutStudyRecruitment(int id, RecruitmentViewModel recruitVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != recruitVM.RecruitmentId)
            {
                return BadRequest();
            }

            var recruit = Mapper.Map<RecruitmentViewModel, Recruitment>(recruitVM);

            db.Entry(recruit).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }


        // PUT: api/Studies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudy(int id, StudyViewModel studyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studyViewModel.StudyId)
            {
                return BadRequest();
            }

            #region SubjectAgeCriteria
            
                if (studyViewModel.GreaterThanEquals)
                {
                    studyViewModel.SubjectMinAgeInequality = "GTOET";
                }
                else if (studyViewModel.GreaterThan )
                {
                    studyViewModel.SubjectMinAgeInequality = "GT";               }

            //Age Min

                var minMonth =(double) studyViewModel.MinMonth/12;               
                studyViewModel.SubjectMinAgeInYears = (double)(studyViewModel.MinYear) + minMonth;
           
                if (studyViewModel.LessThanEquals)
                {
                    studyViewModel.SubjectMaxAgeInequality = "LTOET";
                    
                }
                else if (studyViewModel.LessThan)
                {
                    studyViewModel.SubjectMaxAgeInequality = "LT";                   
                }

            var maxMonth = (double)studyViewModel.MaxMonth / 12;
            studyViewModel.SubjectMaxAgeInYears = (double)(studyViewModel.MaxYear) + maxMonth;

            #endregion
            var studyMapper = new StudyMapper();
            var study = studyMapper.GetStudy(studyViewModel);

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
        public IHttpActionResult PostStudy(StudyViewModel studyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #region SubjectAgeCriteria

            if (studyViewModel.GreaterThanEquals)
            {
                studyViewModel.SubjectMinAgeInequality = "GTOET";
            }
            else if (studyViewModel.GreaterThan)
            {
                studyViewModel.SubjectMinAgeInequality = "GT";
            }

            //Age Min
            var minMonth = (double)studyViewModel.MinMonth / 12;
            studyViewModel.SubjectMinAgeInYears = (double)(studyViewModel.MinYear) + minMonth;

            if (studyViewModel.LessThanEquals)
            {
                studyViewModel.SubjectMaxAgeInequality = "LTOET";

            }
            else if (studyViewModel.LessThan)
            {
                studyViewModel.SubjectMaxAgeInequality = "LT";
            }

            var maxMonth = (double)studyViewModel.MaxMonth / 12;
            studyViewModel.SubjectMaxAgeInYears = (double)(studyViewModel.MaxYear) + maxMonth;

            #endregion

            var studyMapper = new StudyMapper();
            var study = studyMapper.GetStudy(studyViewModel);

            db.Studies.Add(study);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = study.StudyId }, study);
        }

        ///Studies/InformedConsents
        [Route("api/Studies/InformedConsents")]
        public IHttpActionResult PostStudyConsent(InformedConsentViewModel informedConsent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var consent = Mapper.Map<InformedConsentViewModel, InformedConsent>(informedConsent);

            db.InformedConsents.Add(consent);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        ///Studies/InformedConsents
        [Route("api/Studies/Recruitments")]
        public IHttpActionResult PostStudyRecruitment(RecruitmentViewModel recruitmentVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var recruitment = Mapper.Map<RecruitmentViewModel, Recruitment>(recruitmentVM);

            db.Recruitments.Add(recruitment);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
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

        [Route("api/Studies/{id}/visit/{visitId}")]
        public IHttpActionResult DeleteStudyVisit(int id, int visitId)
        {
            Study study = db.Studies.Find(id);

            var visitSchedule = db.VisitSchedules.Where(s=>s.StudyId==id && s.VisitScheduleId==visitId).FirstOrDefault();
            if (visitSchedule == null)
            {
                return NotFound();
            }

            db.VisitSchedules.Remove(visitSchedule);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/Studies/{id}/consent/{consentId}")]
        public IHttpActionResult DeleteStudyConsnent(int id, int consentId)
        {
          

            var consent = db.InformedConsents.Where(s => s.StudyId == id && s.InformedConsentId == consentId).FirstOrDefault();
            if (consent == null)
            {
                return NotFound();
            }

            db.InformedConsents.Remove(consent);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/Studies/{id}/recruit/{recruitId}")]
        public IHttpActionResult DeleteStudyRecruit(int id, int recruitId)
        {


            var recruit = db.Recruitments.Where(r => r.StudyId == id && r.RecruitmentId == recruitId).FirstOrDefault();
            if (recruit == null)
            {
                return NotFound();
            }

            db.Recruitments.Remove(recruit);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
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