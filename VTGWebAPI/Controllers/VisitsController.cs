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
    public class VisitsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/Visits
        public IQueryable<Visit> GetVisits()
        {
            return db.Visits;
        }
        
        // GET: api/Visits
        [Route("api/Visits/{personId}/{studyId}")]
        public IEnumerable<VisitViewModel> GetVisits(int personId, int studyId)
        {

            var subjectStudyLink = db.LinkSubjectsStudies.Where(l => l.PersonId == personId && l.StudyId == studyId).FirstOrDefault();
            var visitsVM =new List<VisitViewModel>();
            if (subjectStudyLink!=null)
            {
                var visits = db.Visits.Where(v => v.SubjectStudyLinkId == subjectStudyLink.SubjectStudyLinkId).OrderBy(v => v.VisitOrder).ToList();
                 visitsVM = Mapper.Map<List<Visit>, List<VisitViewModel>>(visits);
            }
            
            return visitsVM;
        }

        // GET: api/Visits/5
        [ResponseType(typeof(Visit))]
        public VisitViewModel GetVisit(int id)
        {
            Visit visit = db.Visits.Find(id);
            var visitViewModel = Mapper.Map<Visit, VisitViewModel>(visit);

            #region Vaccines

                var vaccines = db.Vaccinations.Where(v => v.VisitId == visit.VisitId).ToList();
                var vaccineVM = Mapper.Map<List<Vaccination>, IEnumerable<VaccineViewModel>>(vaccines);

            visitViewModel.VaccineList = vaccineVM;

            #endregion

            #region Samples
                var samples = db.Samples.Where(v => v.VisitId == visit.VisitId).ToList();
                var samplesVM = Mapper.Map<List<Sample>, IEnumerable<SamplesViewModel>>(samples);
                visitViewModel.SamplesList = samplesVM;
            #endregion

            #region TravelReimbursement
            var travel = db.TravelReimbursements.Where(v => v.VisitId == visit.VisitId).ToList();
            var travelVM = Mapper.Map<List<TravelReimbursement>, IEnumerable<TravelReimbursementViewModel>>(travel);
            foreach (var t in travelVM)
            {
                if (t.ApprovedBy.HasValue)
                {
                    var staff = db.VtgStaffs.Find(t.ApprovedBy.Value);
                    t.ApprovedByName = staff.Surname + ',' + staff.Firstname;
                }
              
            }
            visitViewModel.TravelReimbursementList = travelVM;
            #endregion

            #region Questionnaire
            var questions = db.Questionnaires.Where(v => v.VisitId == visit.VisitId).ToList();
            var questionsVM = Mapper.Map<List<Questionnaire>, IEnumerable<QuestionViewModel>>(questions);
            visitViewModel.QuestionList = questionsVM;
            #endregion


            return visitViewModel;

        }

        // PUT: api/Visits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisit(int id, VisitViewModel visitVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var visit = Mapper.Map<VisitViewModel, Visit>(visitVM);

            if (id != visit.VisitId)
            {
                return BadRequest();
            }
            //Update other related visit Dates
            var study = db.LinkSubjectsStudies.Find(visitVM.SubjectStudyLinkId);
            var visitOrder = db.VisitSchedules.Where(v => v.StudyId == study.StudyId && v.VisitScheduleId == visitVM.VisitScheduleId).Select(v => v.VisitOrder).FirstOrDefault();


            var relatedSVisits = db.VisitSchedules.Where(v=>v.StudyId== study.StudyId && v.VisitOrderThatTimingIsRelativeTo== visitOrder).Select(s=>s.VisitScheduleId).ToList();
            var affectedVisits = db.Visits.Where(v => v.SubjectStudyLinkId == visit.SubjectStudyLinkId).Where(l=>relatedSVisits.Contains(l.VisitScheduleId.Value)).ToList();
            foreach (var aVisit in affectedVisits)
            {
                aVisit.EarliestDate = GetEarliestDate(visit.ActualDate, visit.SubjectStudyLinkId, aVisit.VisitScheduleId.Value);
                aVisit.LatestDate = GetLatestDate(visit.ActualDate, visit.SubjectStudyLinkId, aVisit.VisitScheduleId.Value);
                db.Entry(aVisit).State= EntityState.Modified;
            }

          
            db.Entry(visit).State = EntityState.Modified;

            try
            {
                

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(id))
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

        // POST: api/Visits
        [ResponseType(typeof(Visit))]
        public IHttpActionResult PostVisit(VisitViewModel visitVM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //get the 1st vist detail
            var scheduledVisits = db.VisitSchedules.Where(v => v.StudyId == visitVM.StudyID);
            var visitList = new List<Visit>();
         
            int i = 1;
            foreach (var sVisit in scheduledVisits)
            {
                var visit = new Visit();
                var scheduledVisit = scheduledVisits.Where(vl => vl.VisitOrder == i).FirstOrDefault();
              
                var relativeVisitId = scheduledVisit.VisitOrderThatTimingIsRelativeTo;

                visit.SubjectStudyLinkId = visitVM.SubjectStudyLinkId;             
                visit.VisitScheduleId = scheduledVisit.VisitScheduleId;            
                visit.VisitOrder = scheduledVisit.VisitOrder;
                visit.Description = scheduledVisit.Description;
                if (i == 1)
                {
                    visit.ActualDate = visitVM.ActualDate;
                    visit.VisitCompletedYN = visitVM.VisitCompletedYN;
                }
                if (relativeVisitId == 1 && i!=1)
                {
                    visit.EarliestDate = GetEarliestDate(visitVM.ActualDate, visitVM.SubjectStudyLinkId, scheduledVisit.VisitScheduleId);
                    visit.LatestDate = GetLatestDate(visitVM.ActualDate, visitVM.SubjectStudyLinkId, scheduledVisit.VisitScheduleId);
                }
                
              
                visitList.Add(visit);
                i++;
            }
            db.Visits.AddRange(visitList);
            db.SaveChanges();


            return CreatedAtRoute("DefaultApi", new { id = visitVM.VisitId }, visitVM);
        }

        [Route("api/Visits/{id}/Vaccines")]
        public IHttpActionResult PostVisitVaccine(int id,VaccineViewModel vaccineVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            vaccineVM.Description = db.VaccinationTypes.Find(vaccineVM.TypeVaccinationId).Description;
            var vaccine = Mapper.Map<VaccineViewModel,Vaccination>(vaccineVM);
           
            db.Vaccinations.Add(vaccine);
            db.SaveChanges();

            return Ok(vaccineVM);

        }

        [Route("api/Visits/{id}/Samples")]
        public IHttpActionResult PostVisitSample(int id, SamplesViewModel sampleVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            sampleVM.Description = db.SampleTypes.Find(sampleVM.TypeSampleId).Description;
            var sample = Mapper.Map<SamplesViewModel, Sample>(sampleVM);

            db.Samples.Add(sample);
            db.SaveChanges();


            return Ok(sampleVM);

        }

        [Route("api/Visits/{id}/Questionnaires")]
        public IHttpActionResult PostVisitQuestionnaires(int id, QuestionViewModel questionVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            questionVM.Description = db.QuestionnaireTypes.Find(questionVM.TypeQuestionnaireId).Description;
            var question = Mapper.Map<QuestionViewModel, Questionnaire>(questionVM);

            db.Questionnaires.Add(question);
            db.SaveChanges();
            return   Ok(questionVM);
        }

        [Route("api/Visits/{id}/TravelReimbursements")]
        public IHttpActionResult PostVisitTravelReimbursements(int id,TravelReimbursementViewModel travelVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var travel = Mapper.Map<TravelReimbursementViewModel, TravelReimbursement>(travelVM);

            db.TravelReimbursements.Add(travel);
            db.SaveChanges();

            return Ok(travelVM);

        }

        private DateTime? GetEarliestDate(DateTime? visitDate,int subjectStudyLinkId,int VisitScheduleId )
        {

            var scheduledVisit = db.VisitSchedules.Find(VisitScheduleId);
            DateTime? relativeDate;
            var relativeVisit= new Visit();
            var relativeVisitId = scheduledVisit.VisitOrderThatTimingIsRelativeTo;

            //When Adding Visits
            if (visitDate.HasValue)
            {
                relativeDate = visitDate.Value;
            }

            else {
                  relativeVisit = db.Visits.Where(v => v.SubjectStudyLinkId == subjectStudyLinkId && v.VisitOrder == relativeVisitId).FirstOrDefault();
                  relativeDate = relativeVisit.ActualDate.Value;
            }
               
            
            

            if (scheduledVisit.MinDaysAfterPrevious.HasValue && relativeDate.HasValue)
            {
                var minDaysoffset = (double)scheduledVisit.MinDaysAfterPrevious.Value;
                var earliestDate = relativeDate.Value.AddDays(-minDaysoffset);
                return earliestDate;
            }
            return null;


        }


        private DateTime? GetLatestDate(DateTime? visitDate, int? subjectStudyLinkId, int VisitScheduleId)
        {
            var scheduledVisit = db.VisitSchedules.Find(VisitScheduleId);
            DateTime? relativeDate;
            var relativeVisit = new Visit();
            var relativeVisitId = scheduledVisit.VisitOrderThatTimingIsRelativeTo;

            //When Adding Visits
            if (visitDate.HasValue)
            {
                relativeDate = visitDate.Value;
            }

            else
            {
                relativeVisit = db.Visits.Where(v => v.SubjectStudyLinkId == subjectStudyLinkId && v.VisitOrder == relativeVisitId).FirstOrDefault();
                relativeDate = relativeVisit.ActualDate.Value;
            }


            if (scheduledVisit.MaxDaysAfterPrevious.HasValue && relativeDate.HasValue)
            {
                var maxDaysOffset = (double)scheduledVisit.MaxDaysAfterPrevious.Value;
                var latestDate = relativeDate.Value.AddDays(maxDaysOffset);
                return latestDate;
            }
            return null;


        }
        // DELETE: api/Visits/5
        [ResponseType(typeof(Visit))]
        public IHttpActionResult DeleteVisit(int id)
        {
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return NotFound();
            }

            db.Visits.Remove(visit);
            db.SaveChanges();

            return Ok(visit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitExists(int id)
        {
            return db.Visits.Count(e => e.VisitId == id) > 0;
        }
    }
}